using Application.DTOs.Request;
using Application.DTOs.Response;
using Domain.SeedWork;
using MediatR;

namespace Application.Commands
{
    public class CreateUserCommand : IRequest<ResponseObject<UserCreated>>
    {
        public UserCreateDTO User { get; set; }

        public CreateUserCommand(UserCreateDTO user)
        {
            User = user;
        }
    }
}