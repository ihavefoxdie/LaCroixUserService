using LaCroix.UserService.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaCroix.UserService.Infrastructure.Data
{
    public class UserUnitOfWork : IUnitOfWork
    {
        private readonly UserDbContext _userDbContext;

        public UserUnitOfWork(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _userDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
