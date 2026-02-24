namespace LaCroix.UserService.Application.Contracts;

public interface IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}
