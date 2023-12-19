using AutoMapper;
using MediatR;
using Application.Responses;
using Application.DTOs.Comment;
using Application.DTOs.Comment.Validators;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Comments.Requests.Commands;
using Application.Contracts;
using Domain;

namespace Application.Features.Comments.Handlers.Commands
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, BaseCommandResponse<Comment>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Comment>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Comment>();

            var validator = new UpdateCommentDTOValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateCommentDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Validation failed";
                response.Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return response;
            }

            // Map UpdateCommentDTO to Domain.Comment
            var commentToUpdate = _mapper.Map<Domain.Comment>(request.UpdateCommentDTO);

            // Get the existing comment from the repository
            var existingComment = await _commentRepository.Get(commentToUpdate.ID);

            // Check if the existing comment is found
            if (existingComment == null)
            {
                response.Success = false;
                response.Message = "Comment not found. Update failed.";
                return response;
            }

            // Check if request.AuthorId is equal to comment.AuthorId
            if (request.AuthorID != existingComment.AuthorID)
            {
                response.Success = false;
                response.Message = "Authorization failed: AuthorID does not match.";
                return response;
            }

            // Assume the repository method for updating a comment returns the updated comment
            var updatedComment = await _commentRepository.Update(commentToUpdate);

            response.Success = true;
            response.Message = "Comment updated successfully";
            response.Data = _mapper.Map<Comment>(updatedComment);

            return response;
        }
    }
}
