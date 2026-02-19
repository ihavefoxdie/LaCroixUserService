using LaCroix.UserService.Api.Entities;
using LaCroix.UserService.Api.Mappings;
using LaCroix.UserService.Api.Repositories;
using LaCroix.UserService.Api.Repositories.Interface;
using LaCroix.UserService.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddControllers();
//var config = new MapperConfiguration(cfg =>
//{
//    cfg.CreateMap<UserDTO, User>();
//}, null);
//config.AssertConfigurationIsValid();
//builder.Services.AddAutoMapper(config);


var app = builder.Build();

app.Run();
