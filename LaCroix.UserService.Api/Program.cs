using LaCroix.UserService.Application.Contracts;
using LaCroix.UserService.Application.UseCases;
using LaCroix.UserService.Domain.Contracts;
using LaCroix.UserService.Infrastructure.Data;
using LaCroix.UserService.Infrastructure.Mediation;
using LaCroix.UserService.Infrastructure.Repositories;
using LaCroix.UserService.Infrastructure.Security;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using PostService.RabbitMQ.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddDbContextPool<UserDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("UserServiceConnection"));
});
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
builder.Services.AddScoped<IUnitOfWork, UserUnitOfWork>();
builder.Services.AddScoped<IRequestHandler<UserRegisterRequest, Guid>, UserRegisterHandler>();
builder.Services.AddScoped<IRequestHandler<UserLoginRequest, Guid>, UserLoginHandler>();
builder.Services.AddScoped<IMediator, UserMediator>();
builder.Services.AddMassTransit(mTconfigurator =>
{
    mTconfigurator.SetKebabCaseEndpointNameFormatter();
    mTconfigurator.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(new Uri(builder.Configuration["MessageBroker:Host"]!), h =>
        {
            h.Username(builder.Configuration["MessageBroker:Username"]);
            h.Password(builder.Configuration["MessageBroker:Password"]);
        });

        //configurator.ConfigureEndpoints(context);

        // Настройка exchange для конкретного типа сообщения
        configurator.Message<UserMQEvent>(x =>
        {
            x.SetEntityName("PostService.RabbitMQ.Contracts:UserMQEvent"); // Имя exchange
        });
    });
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "InventoryAPI",
        Version = "v1"
    });

    //var filePath = Path.Combine(System.AppContext.BaseDirectory, "MyApi.xml");
    //options.IncludeXmlComments(filePath);
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UserDbContext>();
    db.Database.Migrate();
}

if (true)
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
