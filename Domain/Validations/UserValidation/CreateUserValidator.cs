using FluentValidation;

namespace Domain.Validations.UserValidation
{
    public class CreateUserValidator : AbstractValidator<User>

    {
        public CreateUserValidator()
        {
            RuleFor(e => e.BirthDate)
                .NotEmpty()
                .NotNull();

            RuleFor(e => e.CPF)
                .NotEmpty()
                .NotNull();

            RuleFor(e => e.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();

            RuleFor(e => e.MotherName)
                .NotEmpty()
                .NotNull();

            RuleFor(e => e.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(e => e.Phone)
                .NotEmpty()
                .NotNull();
        }
    }
}