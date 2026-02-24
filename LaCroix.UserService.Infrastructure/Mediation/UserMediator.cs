using LaCroix.UserService.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace LaCroix.UserService.Infrastructure.Mediation;

public class UserMediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public UserMediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<T2> SendAsync<T1, T2>(T1 request, CancellationToken cancellationToken = default) where T1 : IRequest<T2>
    {
        return await _serviceProvider.GetRequiredService<IRequestHandler<T1, T2>>().HandleAsync(request, cancellationToken);
    }
}
