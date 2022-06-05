using Application.Commands;
using Application.DTOs.Response;
using Domain;
using Domain.SeedWork;
using MediatR;

namespace Application.Handlers
{
    public class UserHandler : IRequestHandler<CreateUserCommand, ResponseObject<UserCreated>>
    {
        public Task<ResponseObject<UserCreated>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            if (!user.IsValid())
            {
                return Task.FromResult(new ResponseObject<UserCreated>(user.ValidationResult));
            }

            throw new NotImplementedException();
        }
    }
}