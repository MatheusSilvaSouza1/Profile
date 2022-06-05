using Application.Commands;
using Application.DTOs.Response;
using AutoMapper;
using Domain;
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
            var user = _mapper.Map<User>(request.User);
            if (!user.IsValid())
                return new ResponseObject<UserCreated>(user.ValidationResult);

            _userRepository.CreateUser(user);

            await _userRepository.UnitOfWork.SaveEntitiesAsync();

            return new ResponseObject<UserCreated>(_mapper.Map<UserCreated>(user));
        }
    }
}