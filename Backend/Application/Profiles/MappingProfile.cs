using Application.DTOs.Rating;
using AutoMapper;
using Domain;
using Application.DTOs.Comment;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        
         public MappingProfile()
         {
            CreateMap<Rating, RatingDto>().ReverseMap();
            CreateMap<Comment, LeaveCommentDTO>().ReverseMap();
            CreateMap<Comment, ReplyToCommentDTO>().ReverseMap();
            CreateMap<Comment, UpdateCommentDTO>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();

         }
    }
}