using Application.Contracts;
using Application.DTOs.Blog;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Blog.Commands.UpdateBlog;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, BlogDto>
{
    private readonly IMapper _mapper;
    private readonly IBlogRepository _blogRepository;
    
    public UpdateBlogCommandHandler(IMapper mapper, IBlogRepository blogRepository)
    {
        _mapper = mapper;
        _blogRepository = blogRepository;
    }
    
    public async Task<BlogDto> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateBlogCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Blog Request", validationResult);

        var blog = _mapper.Map<Domain.Blog>(request);

        await _blogRepository.Update(blog);

        var blogDto = _mapper.Map<BlogDto>(blog);
        
        return blogDto;
    }
}