using LaCroix.UserService.Domain.Users;

namespace LaCroix.UserService.Domain.Contracts;

public interface IUserRepository
{
    public Task AddAsync(User entity, CancellationToken cancellationToken);

    public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    public void Deactivate(User user);
}
