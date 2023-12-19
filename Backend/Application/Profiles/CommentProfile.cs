using Application.DTOs.Comment;
using AutoMapper;
using Domain;

namespace Application.Profiles;

public class CommentProfile: Profile
{
    public CommentProfile()
    {
            CreateMap<Comment, LeaveCommentDTO>().ReverseMap();
            CreateMap<Comment, ReplyToCommentDTO>().ReverseMap();
            CreateMap<Comment, UpdateCommentDTO>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();
    }
}