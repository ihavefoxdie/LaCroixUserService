using LaCroix.UserService.Application.Contracts;

namespace LaCroix.UserService.Application.UseCases;

public record UserRegisterRequest(
    string Nickname,
    string Email,
    string Password,
    string? FirstName,
    string? LastName,
    string? Gender,
    DateTime? Birthday
) : IRequest<Guid>;
