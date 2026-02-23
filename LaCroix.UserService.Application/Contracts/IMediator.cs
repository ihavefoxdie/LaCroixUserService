namespace LaCroix.UserService.Application.Contracts;

public interface IMediator
{
    Task<T1> SendAsync<T1>(IRequest<T1> request, CancellationToken cancellationToken = default);
}

