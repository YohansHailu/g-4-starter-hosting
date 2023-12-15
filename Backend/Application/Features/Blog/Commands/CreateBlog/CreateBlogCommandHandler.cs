using Application.Contracts;
using Application.DTOs.Blog;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Blog.Commands.CreateBlog;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogDto>
{
    private readonly IMapper _mapper;
    private readonly IBlogRepository _blogRepository;
    
    public CreateBlogCommandHandler(IMapper mapper, IBlogRepository blogRepository)
    {
        _mapper = mapper;
        _blogRepository = blogRepository;
    }
    
    public async Task<BlogDto> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine("inside the handler");
        var blog = _mapper.Map<Domain.Blog>(request);

        await _blogRepository.Add(blog);
  
        Console.WriteLine("after the handler");
    
        var blogDto = _mapper.Map<BlogDto>(blog);
        
        return blogDto;
    
    }
}