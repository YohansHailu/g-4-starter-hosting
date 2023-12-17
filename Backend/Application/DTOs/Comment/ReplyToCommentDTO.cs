namespace Application.DTOs.Comment
{
    public class ReplyToCommentDTO
    {
        public string Content { get; set; }
        public Guid ParentCommentID { get; set; }
        
    }
}
