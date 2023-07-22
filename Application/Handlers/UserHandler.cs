using AutoMapper;
using Domain;
using Domain.Commands;
using Domain.DTOs.Response;
using Domain.Repositories;
using Domain.SeedWork;
using MediatR;

namespace Application.Handlers
{
    public class UserHandler : IRequestHandler<CreateUserCommand, ResponseObject<UserCreatedDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ResponseObject<UserCreatedDTO>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Create(request.User);
            if (!user.IsValidCreateUser())
            {
                return new ResponseObject<UserCreatedDTO>(user.ValidationResult);
            }

            _userRepository.CreateUser(user);

            await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return new ResponseObject<UserCreatedDTO>(_mapper.Map<UserCreatedDTO>(user));
        }
    }
}