using MediatR;
using Application.Responses;
using Application.DTOs.Comment;
using Domain;

namespace Application.Features.Comments.Requests.Commands
{
    public class ReplyToCommentCommand : IRequest<BaseCommandResponse<Comment>>
    {
        public ReplyToCommentDTO ReplyToCommentDTO { get; set; }
        public Guid AuthorID { get; set; }
    }
}
