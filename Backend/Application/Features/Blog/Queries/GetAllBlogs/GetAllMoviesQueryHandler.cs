using Application.Contracts;
using Application.DTOs.Blog;
using AutoMapper;
using MediatR;


namespace Application.Features.Blog.Queries.GetAllBlogs;

public class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsQuery, List<BlogDto>>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;
    
    public GetAllBlogsQueryHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }
    
    public async Task<List<BlogDto>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
    {

        var blog = await _blogRepository.GetAll();

        

        var blogDto = _mapper.Map<List<BlogDto>>(blog);

        return blogDto;
    }
}