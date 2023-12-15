using Domain.Common;

namespace Domain;

public class Blog : BaseEntity
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    // Navigation properties
    // public ICollection<Comment> Comments { get; set; }
    public ICollection<Rating> Ratings { get; set; }

}