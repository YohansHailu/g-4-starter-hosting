using Application.Contracts;
using Application.DTOs.Blog;
using AutoMapper;
using MediatR;


namespace Application.Features.Blog.Queries.GetAllBlogs;

public class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsQuery, List<BlogDetailsDto>>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;
    
    public GetAllBlogsQueryHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }
    
    public async Task<List<BlogDetailsDto>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
    {

        var blog = await _blogRepository.GetAll();

        

        var blogDto = _mapper.Map<List<BlogDetailsDto>>(blog);

        return blogDto;
    }
}