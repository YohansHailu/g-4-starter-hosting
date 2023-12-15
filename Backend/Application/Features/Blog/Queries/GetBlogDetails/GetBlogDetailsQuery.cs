using Application.DTOs.Blog;
using MediatR;

namespace Application.Features.Blog.Queries.GetBlogDetails;

public record GetBlogDetailsQuery(Guid Id) : IRequest<BlogDetailsDto>;