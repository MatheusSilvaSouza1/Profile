using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Domain.Validations.UserValidation
{
    public class CreateAddressValidator : AbstractValidator<Address>
    {
        public CreateAddressValidator()
        {
            RuleFor(e => e.City)
                .NotEmpty()
                .NotNull();

            RuleFor(e => e.Country)
                .NotEmpty()
                .NotNull();

            RuleFor(e => e.District)
                .NotEmpty()
                .NotNull();

            RuleFor(e => e.State)
                .NotEmpty()
                .NotNull()
                .Length(2);

            RuleFor(e => e.Street)
                .NotEmpty()
                .NotNull()
                .Length(2);
        }
    }
}