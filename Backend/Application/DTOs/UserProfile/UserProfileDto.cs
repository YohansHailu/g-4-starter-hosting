namespace Application.DTOs.UserProfile;

public class UserProfileDto
{
    
    public Guid UserId { get; set; }
    public DateTime DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string? Bio { get; set; }
    
    public string? TwitterHandle { get; set; }
}