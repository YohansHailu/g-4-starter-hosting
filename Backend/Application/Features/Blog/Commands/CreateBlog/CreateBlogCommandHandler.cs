using Application.Contracts;
using Application.DTOs.Blog;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Blog.Commands.CreateBlog;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Domain.Blog>
{
    private readonly IMapper _mapper;
    private readonly IBlogRepository _blogRepository;

    public CreateBlogCommandHandler(IMapper mapper, IBlogRepository blogRepository)
    {
        _mapper = mapper;
        _blogRepository = blogRepository;
    }

    public async Task<Domain.Blog> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateBlogCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Blog Request", validationResult);

        var blog = _mapper.Map<Domain.Blog>(request.BlogDto);
        return await _blogRepository.Add(blog);
    }
}
