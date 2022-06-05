using Application.Commands;
using Application.DTOs.Response;
using MediatR;

namespace Application.Handlers
{
    public class UserHandler : IRequestHandler<CreateUserCommand, UserCreated>
    {
        public Task<UserCreated> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            
            throw new NotImplementedException();
        }
    }
}