using Domain.DTOs.Request;
using Domain.DTOs.Response;
using Domain.SeedWork;
using MediatR;

namespace Domain.Commands
{
    public sealed record CreateAddressCommand(
        string UserId,
        CreateAddressDTO Address)
    : IRequest<ResponseObject<AddressCreatedDTO>>;
}