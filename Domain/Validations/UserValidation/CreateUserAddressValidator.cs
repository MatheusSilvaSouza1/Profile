using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Domain.Validations.UserValidation
{
    public class CreateUserAddressValidator : AbstractValidator<User>
    {
        public CreateUserAddressValidator(Address address)
        {
            RuleFor(e => e.Addresses.Append(address).Count(a => a.IsDefault))
                .LessThanOrEqualTo(1)
                .WithMessage("Só é permitido um endereço padrão por usuário");

            RuleFor(e => address)
                .SetValidator(new CreateAddressValidator());
        }
    }
}