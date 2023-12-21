using Application.DTOs.Blog;
using MediatR;

namespace Application.Features.Blog.Queries.GetAllBlogs;

public record GetAllBlogsQuery : IRequest<List<BlogDetailsDto>>;