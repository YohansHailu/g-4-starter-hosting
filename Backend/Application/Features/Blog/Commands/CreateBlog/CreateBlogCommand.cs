using Application.DTOs.Blog;
using MediatR;

namespace Application.Features.Blog.Commands.CreateBlog;

public class CreateBlogCommand : IRequest<BlogDto>
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}