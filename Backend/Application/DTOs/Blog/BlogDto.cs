using System;
using System.Collections.Generic;
using Domain;

namespace Application.DTOs.Blog
{
    public class BlogDto
    {
        public Guid? AutherId { set; get; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}