namespace LaCroix.UserService.Application.Contracts;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T1">Request type.</typeparam>
/// <typeparam name="T2">Response type.</typeparam>
public interface IRequestHandler<T1, T2> where T1 : IRequest<T2>
{
    Task<T2> HandleAsync(T1 request, CancellationToken cancellationToken);
}
