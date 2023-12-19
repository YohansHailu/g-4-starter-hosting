using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.userAuthDto;
public class RegisterDto
{
    public string name { get; set; }
    [Required]
    public string userName { get; set; }
    [Required]
    public string email { get; set; }
    [Required]
    public string password { get; set; }
    
}