using AutoMapper;
using LaCroix.UserService.Api.Entities;
using LaCroix.UserService.Api.Repositories.Interface;
using LaCroix.UserService.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaCroix.UserService.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }




    [HttpPost]
    public async Task<ActionResult<UserDTO>> CreateUser(UserDTO userDTO)
    {
        User user = _mapper.Map<User>(userDTO);
        User createdUser = await _userRepository.Add(user);
        if (createdUser == null)
        {
            return BadRequest();
        }

        UserDTO createdUserDTO = _mapper.Map<UserDTO>(createdUser);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUserDTO);
    }

    [HttpGet]
    public async Task<ActionResult<UserDTO>> GetUserById(int id)
    {
        User? user = await _userRepository.GetById(id);
        if (user is null) {
            return NotFound();
        }
        UserDTO? userDTO = _mapper.Map<UserDTO>(user);

        return Ok(userDTO);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
    {
        IEnumerable<User> users = await _userRepository.GetAll();
        IEnumerable<UserDTO> userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);

        return Ok(userDTOs);
    }

    [HttpPut]
    public async Task<ActionResult<UserDTO>> UpdateUser(UserDTO userDTO)
    {
        User user = _mapper.Map<User>(userDTO);
        User? updatedUser = await _userRepository.Update(user);
        if (updatedUser == null)
        {
            return NotFound();
        }

        UserDTO updatedUserDTO = _mapper.Map<UserDTO>(updatedUser);
        return Ok(updatedUserDTO);
    }
     [HttpDelete]
     public async Task<IActionResult> DeleteUser(int id)
     {
         await _userRepository.Delete(id);
         return NoContent();
     }
}