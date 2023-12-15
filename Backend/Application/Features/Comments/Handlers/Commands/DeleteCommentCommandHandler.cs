using MediatR;
using Application.Responses;
using Domain;
using Application.DTOs.Comment;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Comments.Requests.Commands;
using Application.Contracts;
using Application.DTOs.Comment.Validators;

namespace Application.Features.Comments.Handlers.Commands
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, BaseCommandResponse>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            
            Comment comment = await _commentRepository.GetById(request.DeleteCommentDTO.ID);

            // Assume the repository method for deleting a comment returns a boolean indicating success
            

            if (comment != null)

            {
                await _commentRepository.Delete(comment);
                response.Success = true;
                response.Message = "Comment deleted successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "Comment deletion failed";
            }

            return response;
        }
    }
}
