using LaCroix.UserService.Application.Common.Parser;
using LaCroix.UserService.Application.Contracts;
using LaCroix.UserService.Domain.Contracts;
using LaCroix.UserService.Domain.Users;

namespace LaCroix.UserService.Application.UseCases;

public class UserRegisterHandler : IRequestHandler<UserRegisterRequest, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;

    public UserRegisterHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid> HandleAsync(UserRegisterRequest userRegisterRequest, CancellationToken cancellationToken)
    {
        Email email = new(userRegisterRequest.Email);

        if (await _userRepository.GetByEmailAsync(email, cancellationToken) is not null)
        {
            throw new InvalidOperationException("Email is already in use.");
        }

        string passwordHash = _passwordHasher.Hash(userRegisterRequest.Password);

        User user = new(
            nickname: userRegisterRequest.Nickname,
            email: email,
            firstName: userRegisterRequest.FirstName,
            lastName: userRegisterRequest.LastName,
            passwordHash: passwordHash,
            gender: GenderParser.ParseGender(userRegisterRequest.Gender),
            birthday: userRegisterRequest.Birthday,
            role: UserRole.User,
            status: Status.Active
            );

        await _userRepository.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
