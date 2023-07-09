using Domain.Commands;
using Domain.DTOs.Request;
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
        var result = await _handler.Send(new CreateUserCommand(user));
        if (!result.ValidationResult.IsValid)
            return BadRequest(result.ValidationResult);

        return Created("", result.Data);
    }
}
