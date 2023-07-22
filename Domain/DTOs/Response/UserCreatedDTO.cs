namespace Domain.DTOs.Response
{
    public class UserCreatedDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CPF { get; set; }
        public string BirthDate { get; set; }
        public string MotherName { get; set; }
        public LoginCreatedDTO Login { get; set; }
    }
}