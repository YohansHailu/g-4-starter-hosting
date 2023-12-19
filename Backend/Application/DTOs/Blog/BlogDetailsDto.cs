using System;
using System.Collections.Generic;
using Domain;

namespace Application.DTOs.Blog
{
    public class BlogDetailsDto
    {
        public Guid id { get; set; }
        public Guid? AutherId { set; get; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        // public List<Comment> Comments { get; set; } = null!;
        public List<Domain.Rating> Ratings { get; set; } = null!;
    }
}