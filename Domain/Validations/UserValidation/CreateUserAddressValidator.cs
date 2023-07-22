using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Domain.Validations.UserValidation
{
    public class CreateUserAddressValidator : AbstractValidator<User>
    {
        public CreateUserAddressValidator()
        {
            RuleFor(e => e.Addresses.Count(a => a.IsDefault))
                .LessThanOrEqualTo(1)
                .WithMessage("Só é permitido um endereço padrão por usuário");

            RuleForEach(e => e.Addresses)
                .SetValidator(new CreateAddressValidator());
        }
    }
}