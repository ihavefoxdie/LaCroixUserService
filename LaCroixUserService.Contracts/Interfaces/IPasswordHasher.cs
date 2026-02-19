using System;
using System.Collections.Generic;
using System.Text;

namespace LaCroix.UserService.Contracts.Interfaces
{
    public interface IPasswordHasher
    {
        public string Hash(string password);
        public bool Verify(string password, string hash);
    }
}
