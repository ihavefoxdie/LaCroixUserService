using LaCroix.UserService.Application.Contracts;
using LaCroix.UserService.Application.UseCases;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PostService.RabbitMQ.Contracts;
using PostService.RabbitMQ.Enums;

namespace LaCroix.UserService.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _userMediator;
    private readonly IPublishEndpoint _publishEndpoint;

    public UserController(IMediator mediator, IPublishEndpoint publishEndpoint)
    {
        _userMediator = mediator;
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> RegisterUser([FromBody] UserRegisterRequest userRegisterRequest, CancellationToken cancellationToken)
    {
        try
        {
            Guid userId = await _userMediator.SendAsync<UserRegisterRequest, Guid>(userRegisterRequest, cancellationToken);

            var user = new UserMQEvent()
            {
                ID = userId,
                Nickname = userRegisterRequest.Nickname,
                Name = userRegisterRequest.FirstName,
                LastName = userRegisterRequest.LastName,
                Email = userRegisterRequest.Email,
                Operation = OperationTypes.Create,
                OperationTime = DateTime.UtcNow
            };

            await _publishEndpoint.Publish(user, cancellationToken);

            return Ok(userId);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<Guid>> LoginUser([FromBody] UserLoginRequest userLoginRequest, CancellationToken cancellationToken)
    {
        try
        {
            Guid userId = await _userMediator.SendAsync<UserLoginRequest, Guid>(userLoginRequest, cancellationToken);
            return Ok(userId);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
