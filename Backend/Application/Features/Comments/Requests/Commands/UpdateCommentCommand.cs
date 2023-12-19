using MediatR;
using Application.Responses;
using Application.DTOs.Comment;
using Domain;

namespace Application.Features.Comments.Requests.Commands
{
    public class UpdateCommentCommand : IRequest<BaseCommandResponse<Comment>>
    {
        public UpdateCommentDTO UpdateCommentDTO { get; set; }
        public Guid AuthorID { get; set; }
    }
}
