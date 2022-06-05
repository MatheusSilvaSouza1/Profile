using Application.DTOs.Request;
using Application.DTOs.Response;
using MediatR;

namespace Application.Commands
{
    public class CreateUserCommand : IRequest<UserCreated>
    {
        public UserCreateDTO User { get; set; }

        public CreateUserCommand(UserCreateDTO user)
        {
            User = user;
        }
    }
}