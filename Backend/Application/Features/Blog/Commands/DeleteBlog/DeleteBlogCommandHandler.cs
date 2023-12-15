using System.Data.Common;
using Application.Contracts;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Blog.Commands.DeleteBlog;

public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, Unit>
{
    private readonly IBlogRepository _blogRepository;
    
    public DeleteBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }
    
    public async Task<Unit> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {

        var blogToDelete = await _blogRepository.Get(request.Id);

        if (blogToDelete == null)
            throw new Exception("blog not found");
      

        await _blogRepository.Delete(blogToDelete);
        
        return Unit.Value;
    }
}