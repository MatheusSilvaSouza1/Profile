using Application.Commands;
using Application.DTOs.Response;
using AutoMapper;
using Domain;
using Domain.SeedWork;
using MediatR;

namespace Application.Handlers
{
    public class UserHandler : IRequestHandler<CreateUserCommand, ResponseObject<UserCreated>>
    {
        private readonly IMapper _mapper;
        public UserHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ResponseObject<UserCreated>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.User);
            if (!user.IsValid())
                return new ResponseObject<UserCreated>(user.ValidationResult);

            
            

            throw new NotImplementedException();
        }
    }
}