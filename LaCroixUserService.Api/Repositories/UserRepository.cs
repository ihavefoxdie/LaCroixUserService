using LaCroix.UserService.Api.Data;
using LaCroix.UserService.Api.Entities;
using LaCroix.UserService.Api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace LaCroix.UserService.Api.Repositories;

public class UserRepository : IUserRepository, IDisposable
{
    private bool _disposed = false;
    private readonly UserDbContext _userDbContext;

    public UserRepository(UserDbContext userDbContext)
    {
        _userDbContext = userDbContext;
    }




    public async Task<User?> Add(User entity)
    {
        await _userDbContext.AddAsync(entity);
        await _userDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _userDbContext.Users.AsNoTracking().ToListAsync();
    }

    public async Task<User?> GetById(Guid id)
    {
        User? foundUser = await _userDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (foundUser != null)
        {
            return foundUser;
        }

        return foundUser;
    }

    public async Task<User?> Update(User entity)
    {
        User? foundUser = await _userDbContext.Users.FirstOrDefaultAsync(x => x.Id == entity.Id);

        if (foundUser != null)
        {
            foundUser.Nickname = entity.Nickname;
            foundUser.Email = entity.Email;
            foundUser.PasswordHash = entity.PasswordHash;
            foundUser.FirstName = entity.FirstName;
            foundUser.LastName = entity.LastName;
            foundUser.Gender = entity.Gender;
            foundUser.Birthday = entity.Birthday;
            foundUser.UpdatedDate = DateTime.UtcNow;
            foundUser.Status = entity.Status;
            foundUser.Role = entity.Role;
            
            await _userDbContext.SaveChangesAsync();
        }
        return foundUser;
    }
    public async Task Delete(Guid id)
    {
        User? foundUser = await _userDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (foundUser != null)
        {
            _userDbContext.Users.Remove(foundUser);
            await _userDbContext.SaveChangesAsync();
        }
    }




    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _userDbContext.Dispose();
            }
            _disposed = true;
        }
    }
}