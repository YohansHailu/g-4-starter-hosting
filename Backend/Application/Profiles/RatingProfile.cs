using Application.DTOs.Rating;
using AutoMapper;
using Domain;
using Application.DTOs.Comment;

namespace Application.Profiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<Rating, RatingDto>().ReverseMap();
            CreateMap<Comment, LeaveCommentDTO>().ReverseMap();
            CreateMap<Comment, ReplyToCommentDTO>().ReverseMap();
            CreateMap<Comment, UpdateCommentDTO>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();
        }
    }
}
