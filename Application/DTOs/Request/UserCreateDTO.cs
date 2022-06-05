namespace Application.DTOs.Request;

public class UserCreateDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string CPF { get; set; }
    public DateTime BirthDate { get; set; }
    public string MotherName { get; set; }
    public LoginCreateDTO Login { get; set; }
}