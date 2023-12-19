using MediatR;
using Application.Responses;
using Application.Features.Comments.Requests.Commands;
using Application.Contracts;

namespace Application.Features.Comments.Handlers.Commands
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, BaseCommandResponse<Guid>>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<BaseCommandResponse<Guid>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Guid>();

            var comment = await _commentRepository.Get(request.DeleteCommentDTO.ID);

            if (comment != null)
            {
                // Check if the provided AuthorID matches the AuthorID of the comment
                if (comment.AuthorID == request.AuthorID)
                {
                    await _commentRepository.DeleteCommentAndReplies(request.DeleteCommentDTO.ID);
                    response.Success = true;
                    response.Message = "Comment deleted successfully";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Authorization failed: AuthorID does not match.";
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Comment not found. Deletion failed.";
            }

            return response;
        }
    }
}