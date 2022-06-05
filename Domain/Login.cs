using Domain.SeedWork;
using FluentValidation;

namespace Domain
{
    public class Login : Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid UserId { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}