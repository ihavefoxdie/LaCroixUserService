namespace LaCroix.UserService.Application.Contracts;

public interface IMediator
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1">Request type.</typeparam>
    /// <typeparam name="T2">Response type.</typeparam>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<T2> SendAsync<T1, T2>(T1 request, CancellationToken cancellationToken = default) where T1 : IRequest<T2>;
}

