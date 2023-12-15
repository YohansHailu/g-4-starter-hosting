using MediatR;
using Application.Responses;
using Application.DTOs.Comment;

namespace Application.Features.Comments.Requests.Commands
{
    public class UpdateCommentCommand : IRequest<CommentDTO>
    {
        public UpdateCommentDTO UpdateCommentDTO { get; set; }
    }
}
