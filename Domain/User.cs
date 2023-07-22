using Domain.DTOs.Request;
using Domain.SeedWork;
using Domain.Types;
using Domain.Validations.UserValidation;

namespace Domain
{
    public class User : Entity, IAggregateRoot
    {
        [Obsolete("Construtor criado apenas para o funcionamento do ef")]
        public User()
        {
        }

        private User(string name, string email, Phone phone, Cpf cPF, DateTime birthDate, string motherName, Login login)
        {
            Name = name;
            Email = email;
            Phone = phone;
            CPF = cPF;
            BirthDate = birthDate;
            MotherName = motherName;
            Login = login;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public Phone Phone { get; set; }
        public Cpf CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public string MotherName { get; set; }
        public Login Login { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public static User Create(UserCreateDTO user)
        => new(user.Name, user.Email, user.Phone,
            user.CPF, user.BirthDate, user.MotherName,
            new Login(user.Login.UserName, user.Login.Password));

        public bool IsValid()
        {
            ValidationResult = new CreateUserValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}