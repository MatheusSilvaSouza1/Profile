using AutoMapper;
using Domain;
using Domain.Commands;
using Domain.DTOs.Response;
using Domain.Repositories;
using Domain.SeedWork;
using FluentValidation.Results;
using MediatR;

namespace Application.Handlers
{
    public class UserHandler :
        IRequestHandler<CreateUserCommand, ResponseObject<UserCreatedDTO>>,
        IRequestHandler<CreateAddressCommand, ResponseObject<AddressCreatedDTO>>
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
                return ResponseObject<UserCreatedDTO>.Failure(user.ValidationResult);
            }

            _userRepository.CreateUser(user);

            await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return ResponseObject<UserCreatedDTO>.Success(_mapper.Map<UserCreatedDTO>(user));
        }

        public async Task<ResponseObject<AddressCreatedDTO>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindOne(request.UserId);
            if (user == null)
            {
                var failure = ResponseObject<AddressCreatedDTO>.Failure(new ValidationResult());
                failure.AddError("create.address", "Usuário não existe!");
                return failure;
            }

            // var address = _mapper.Map<Address>(request.Address);
            var result = user.CreateAddress(request.Address);

            if (result.IsValid)
            {
                await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                return ResponseObject<AddressCreatedDTO>.Success(null);
            }

            return ResponseObject<AddressCreatedDTO>.Failure(result);
        }
    }
}