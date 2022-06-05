using Domain.SeedWork;
using FluentValidation;

namespace Domain
{
    public class Login : Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}