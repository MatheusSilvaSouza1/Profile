using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTOs.Response
{
    public sealed record AddressCreatedDTO(
        string Id,
        string Street,
        string District,
        string City,
        string State,
        string Country,
        bool IsDefault);
}