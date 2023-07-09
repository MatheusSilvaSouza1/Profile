using Domain.SeedWork;
using Domain.Validations.UserValidation;

namespace Domain
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public string MotherName { get; set; }
        public Login Login { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CreateUserValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}