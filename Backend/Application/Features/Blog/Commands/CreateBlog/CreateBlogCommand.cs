using Application.DTOs.Blog;
using MediatR;

namespace Application.Features.Blog.Commands.CreateBlog;

public class CreateBlogCommand : IRequest<Domain.Blog>
{
    public BlogDto BlogDto { set; get; }
}