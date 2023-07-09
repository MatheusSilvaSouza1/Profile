using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Request;

public class UserCreateDTO
{
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string Phone { get; set; }

    [Required]
    public string CPF { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public string MotherName { get; set; }

    [Required]
    public LoginCreateDTO Login { get; set; }
}