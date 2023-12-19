using MediatR;
using Application.Responses;
using Application.DTOs.Comment;

namespace Application.Features.Comments.Requests.Commands
{
    public class UpdateCommentCommand : IRequest<BaseCommandResponse<CommentDTO>>
    {
        public UpdateCommentDTO UpdateCommentDTO { get; set; }
        public Guid AuthorID { get; set; }
    }
}
