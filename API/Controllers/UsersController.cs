using AutoMapper;
using Domain.Commands;
using Domain.DTOs.Request;
using Domain.DTOs.Response;
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
    private readonly IMapper _mapper;

    public UsersController(IMediator handler, IUserRepository userRepository, IMapper mapper)
    {
        _handler = handler;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserCreateDTO user, CancellationToken cancellationToken)
    {
        var result = await _handler.Send(new CreateUserCommand(user), cancellationToken);
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
            return Ok(_mapper.Map<List<UserSummaryDTO>>(users));
        }

        return NoContent();
    }

    [HttpPost("{userId}/address")]
    public async Task<IActionResult> PostAddress(Guid userId, [FromBody] CreateAddressDTO address, CancellationToken cancellationToken)
    {
        var command = new CreateAddressCommand(userId, address);
        var result = await _handler.Send(command, cancellationToken);
        if (!result.ValidationResult.IsValid)
        {
            return BadRequest(result.ValidationResult);
        }

        return Created(string.Empty, result.Data);
    }
}