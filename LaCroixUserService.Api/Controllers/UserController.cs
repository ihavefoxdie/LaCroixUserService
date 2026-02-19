using LaCroix.UserService.Api.Entities;
using LaCroix.UserService.Api.Mappings;
using LaCroix.UserService.Api.Repositories.Interface;
using LaCroix.UserService.Contracts.Enums;
using LaCroix.UserService.Contracts.Interfaces;
using LaCroix.UserService.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaCroix.UserService.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UserController(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }




    [HttpPost]
    public async Task<ActionResult<UserDTO>> CreateUser([FromBody] CreateUserRequest createUserRequest)
    {
        User user = new()
        {
            Username = createUserRequest.Username,
            Email = createUserRequest.Email,
            PasswordHash = _passwordHasher.Hash(createUserRequest.Password),
            Name = createUserRequest.Name,
            Gender = createUserRequest.Gender,
            Birthday = createUserRequest.Birthday,
            CreatedDate = DateTime.UtcNow,
            Status = Status.Active,
            Role = UserRole.User
        };

        User? createdUser = await _userRepository.Add(user);
        if (createdUser == null)
        {
            return BadRequest();
        }

        UserDTO createdUserDTO = UserMapping.UserToUserDTO(createdUser);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUserDTO);
    }

    [HttpGet]
    public async Task<ActionResult<UserDTO>> GetUserById(int id)
    {
        User? user = await _userRepository.GetById(id);
        if (user is null) {
            return NotFound();
        }
        UserDTO? userDTO = UserMapping.UserToUserDTO(user);

        return Ok(userDTO);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
    {
        IEnumerable<User> users = await _userRepository.GetAll();
        IEnumerable<UserDTO> userDTOs = UserMapping.UsersToUserDTOs(users);

        return Ok(userDTOs);
    }

    [HttpPut]
    public async Task<ActionResult<UserDTO>> UpdateUser([FromBody] UpdateUserRequest updateUserRequest)
    {
        User? user = await _userRepository.GetById(updateUserRequest.Id);
        if (user is null)
        {
            return NotFound();
        }

        user.Username = updateUserRequest.Username;
        user.Email = updateUserRequest.Email;
        user.PasswordHash = string.IsNullOrEmpty(updateUserRequest.Password) ? user.PasswordHash : _passwordHasher.Hash(updateUserRequest.Password);
        user.Name = updateUserRequest.Name;
        user.Gender = updateUserRequest.Gender;
        user.Birthday = updateUserRequest.Birthday;
        user.UpdatedDate = DateTime.UtcNow;

        User? updatedUser = await _userRepository.Update(user);
        if (updatedUser == null)
        {
            return BadRequest();
        }

        UserDTO updatedUserDTO = UserMapping.UserToUserDTO(updatedUser);
        return Ok(updatedUserDTO);
    }

     [HttpDelete]
     public async Task<IActionResult> DeleteUser(int id)
     {
         await _userRepository.Delete(id);
         return NoContent();
     }
}