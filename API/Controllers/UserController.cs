using Application.Commands;
using Application.DTOs.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _handler;
    public UserController(IMediator handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserCreateDTO user)
    {
        var a = await _handler.Send(new CreateUserCommand(user));
        return Ok(user);
    }
}
