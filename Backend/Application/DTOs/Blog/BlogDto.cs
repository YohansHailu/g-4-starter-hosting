using System;
using System.Collections.Generic;
using Domain;

namespace Application.DTOs.Blog
{
    public class BlogDto
    {

        public Guid id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        // public List<Comment> Comments { get; set; } = null!;
        // public List<Domain.Rating> Ratings { get; set; } = null!;
    }
}