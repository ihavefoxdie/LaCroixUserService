using Microsoft.EntityFrameworkCore;

namespace LaCroixUserService.Api.Data
{
    public class UserDbContext: DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            
        }
    }
}
