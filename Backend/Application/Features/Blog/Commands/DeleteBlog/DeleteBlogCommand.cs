using MediatR;

namespace Application.Features.Blog.Commands.DeleteBlog;

public class DeleteBlogCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

}