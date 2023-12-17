using MediatR;
using Application.Responses;
using Application.DTOs.Comment;

namespace Application.Features.Comments.Requests.Commands
{
    public class LeaveCommentCommand : IRequest<BaseCommandResponse>
    {
        public LeaveCommentDTO LeaveCommentDTO { get; set; }
    }
}
