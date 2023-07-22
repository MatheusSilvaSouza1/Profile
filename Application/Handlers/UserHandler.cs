using AutoMapper;
using Domain;
using Domain.Commands;
using Domain.DTOs.Response;
using Domain.Repositories;
using Domain.SeedWork;
using MediatR;

namespace Application.Handlers
{
    public class UserHandler : IRequestHandler<CreateUserCommand, ResponseObject<UserCreated>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ResponseObject<UserCreated>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Create(request.User);
            if (!user.IsValid())
            {
                return new ResponseObject<UserCreated>(user.ValidationResult);
            }

            _userRepository.CreateUser(user);

            await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return new ResponseObject<UserCreated>(_mapper.Map<UserCreated>(user));
        }
    }
}