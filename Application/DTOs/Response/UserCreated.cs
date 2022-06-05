namespace Application.DTOs.Response
{
    public class UserCreated
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public string CPF { get; set; }
        public string BirthDate { get; set; }
        public string MotherName { get; set; }
    }
}