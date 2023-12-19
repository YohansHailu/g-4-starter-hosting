using MediatR;
using Application.Responses;
using Application.DTOs.Comment;

namespace Application.Features.Comments.Requests.Commands
{
    public class ReplyToCommentCommand : IRequest<BaseCommandResponse<CommentDTO>>
    {
        public ReplyToCommentDTO ReplyToCommentDTO { get; set; }
        public Guid AuthorID { get; set; }
    }
}
