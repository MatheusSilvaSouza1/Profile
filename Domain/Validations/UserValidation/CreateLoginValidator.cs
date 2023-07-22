using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Domain.Validations.UserValidation
{
    public class CreateLoginValidator : AbstractValidator<Login>
    {
        public CreateLoginValidator()
        {
            RuleFor(e => e.UserName)
                .NotNull()
                .NotEmpty()
                .Length(3, 20);

            RuleFor(e => e.Password)
                .NotNull()
                .NotEmpty()
                .Length(6, 20);
        }
    }
}