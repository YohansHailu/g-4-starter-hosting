using Application.DTOs.Blog;
using MediatR;

namespace Application.Features.Blog.Commands.UpdateBlog;

public class UpdateBlogCommand : IRequest<BlogDto>
{
    public Guid Id {get; set;}
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}