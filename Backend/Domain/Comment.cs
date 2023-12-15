using Domain.Common;


namespace Domain;

public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public Guid? ArticleID { get; set; }

        // Foreign Key for the User who authored the comment
        public Guid AuthorID { get; set; }

        // Navigation property for the User who authored the comment
        public User Author { get; set; }

        // Foreign Key for the Parent Comment (if it's a reply)
        public Guid? ParentCommentID { get; set; }

        // Navigation property for the Parent Comment
        public Comment ParentComment { get; set; }

        // Navigation property for the list of replied comments
        public List<Comment> RepliedComments { get; set; } = new List<Comment>();
}

