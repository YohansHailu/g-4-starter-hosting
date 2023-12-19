using Application.Contracts;
using Application.DTOs.Blog;
using Application.Exceptions;
using AutoMapper;
using MediatR;


namespace Application.Features.Blog.Queries.GetBlogDetails;

public class GetBlogDetailsQueryHandler : IRequestHandler<GetBlogDetailsQuery, BlogDetailsDto>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;
    
    public GetBlogDetailsQueryHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }
    
    public async Task<BlogDetailsDto> Handle(GetBlogDetailsQuery request, CancellationToken cancellationToken)
    {
        var blog = await _blogRepository.Get(request.Id);

        if (blog == null)
            throw new NotFoundException(nameof(Domain.Blog), request.Id);
      

        var blogDto = _mapper.Map<BlogDetailsDto>(blog);
        return blogDto;
    }
}