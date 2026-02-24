using LaCroix.UserService.Application.Contracts;
using LaCroix.UserService.Domain.Contracts;
using LaCroix.UserService.Domain.Users;

namespace LaCroix.UserService.Application.UseCases
{
    public class UserLoginHandler : IRequestHandler<UserLoginRequest, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        
        public UserLoginHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> HandleAsync(UserLoginRequest userLoginRequest, CancellationToken cancellationToken)
        {
            Email email = new (userLoginRequest.Email);

            var user = await _userRepository.GetByEmailAsync(email, cancellationToken);
            if (user is null || !_passwordHasher.Verify(userLoginRequest.Password, user.PasswordHash))
            {
                throw new InvalidOperationException("Invalid email or password.");
            }

            return user.Id;
        }
    }
}
