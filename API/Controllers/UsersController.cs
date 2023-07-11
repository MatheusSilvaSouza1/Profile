using Domain.Commands;
using Domain.DTOs.Request;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _handler;
    private readonly IUserRepository _userRepository;

    public UsersController(IMediator handler, IUserRepository userRepository)
    {
        _handler = handler;
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserCreateDTO user)
    {
        var result = await _handler.Send(new CreateUserCommand(user));
        if (!result.ValidationResult.IsValid)
        {
            return BadRequest(result.ValidationResult);
        }

        return Created(string.Empty, result.Data);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _userRepository.FindAllUser();
        if (users.Any())
        {
            return Ok(users);
        }

        return NoContent();
    }
}