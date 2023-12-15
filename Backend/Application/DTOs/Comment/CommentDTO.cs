namespace Application.DTOs.Comment
{
   public class CommentDTO
{
    public Guid CommentID { get; set; }
    public Guid ArticleID { get; set; }
    public string Content { get; set; }
    public Guid? ParentCommentID { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Additional properties for Parent Comment and Author information
    public CommentDTO ParentComment { get; set; }
    public UserDTO Author { get; set; }
}

public class UserDTO
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    // Add other user-related properties as needed
}


}
