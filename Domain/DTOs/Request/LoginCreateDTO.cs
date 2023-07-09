using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Request
{
    public class LoginCreateDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}