using MediatR;
using Application.Responses;
using Application.DTOs.Comment;

namespace Application.Features.Comments.Requests.Commands
{
    public class DeleteCommentCommand : IRequest<BaseCommandResponse<Guid>>
    {
        public DeleteCommentDTO DeleteCommentDTO { get; set; }
        public Guid AuthorID { get; set; }
    }
}
