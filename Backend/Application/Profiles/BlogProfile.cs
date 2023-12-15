using Application.DTOs.Blog;
using Application.Features.Blog.Commands.CreateBlog;
using Application.Features.Blog.Commands.UpdateBlog;
using AutoMapper;
using Domain;

namespace Application.Profiles;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
        CreateMap<BlogDto, Blog>().ReverseMap();
        CreateMap<CreateBlogCommand, Blog>();
        CreateMap<UpdateBlogCommand, Blog>();
        CreateMap<Blog, BlogDetailsDto>();
    }
}