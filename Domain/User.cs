using Domain.SeedWork;
using Domain.Validations.UserValidation;

namespace Domain
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public string MotherName { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CreateUserValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}