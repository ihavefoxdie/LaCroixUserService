using LaCroix.UserService.Application.Contracts;

namespace LaCroix.UserService.Application.UseCases;

public record UserLoginRequest(string Email, string Password) : IRequest<Guid>;
