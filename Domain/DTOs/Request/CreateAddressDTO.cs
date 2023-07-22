namespace Domain.DTOs.Request
{
    public sealed record CreateAddressDTO(string UserId, string Street, string District, string City, string State, string Country, bool IsDefault);
}