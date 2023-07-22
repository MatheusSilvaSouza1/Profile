using Domain.DTOs.Request;
using Domain.DTOs.Response;
using Domain.SeedWork;
using MediatR;

namespace Domain.Commands
{
    public sealed class CreateUserCommand : IRequest<ResponseObject<UserCreatedDTO>>
    {
        public UserCreateDTO User { get; set; }

        public CreateUserCommand(UserCreateDTO user)
        {
            User = user;
        }
    }
}