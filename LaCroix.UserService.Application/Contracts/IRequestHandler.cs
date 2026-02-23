namespace LaCroix.UserService.Application.Contracts;

public interface IRequestHandler<T1, T2> where T1 : IRequest<T2>
{
    Task<T2> HandleAsync(T1 request, CancellationToken cancellationToken);
}
