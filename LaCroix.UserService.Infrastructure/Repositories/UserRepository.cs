using LaCroix.UserService.Domain.Contracts;
using LaCroix.UserService.Domain.Users;
using LaCroix.UserService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LaCroix.UserService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _dbContext;

    public UserRepository(UserDbContext userDbContext)
    {
        _dbContext = userDbContext;
    }

    public async Task AddAsync(User entity, CancellationToken cancellationToken)
    {
        await _dbContext.Users.AddAsync(entity, cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
