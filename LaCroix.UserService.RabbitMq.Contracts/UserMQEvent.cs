using LaCroix.UserService.RabbitMq.Contracts.Enums;

namespace LaCroix.UserService.RabbitMq.Contracts;

public record UserMQEvent(
    Guid ID,
    string Nickname,
    string Name,
    string LastName,
    string Email,
    OperationTypes Operation,
    DateTime OperationTime
);
