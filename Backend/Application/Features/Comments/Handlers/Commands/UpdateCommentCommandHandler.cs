using AutoMapper;
using MediatR;
using Application.Responses;
using Application.DTOs.Comment;
using Application.DTOs.Comment.Validators;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Comments.Requests.Commands;
using Application.Contracts;

namespace Application.Features.Comments.Handlers.Commands
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, CommentDTO>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CommentDTO> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            

            var validator = new UpdateCommentDTOValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateCommentDTO);

            if (!validationResult.IsValid)
            {
                
                return null;
                
            }

            // Map UpdateCommentDTO to Domain.Comment
            var commentToUpdate = _mapper.Map<Domain.Comment>(request.UpdateCommentDTO);

            // Assume the repository method for updating a comment returns the updated comment
            var updatedComment = await _commentRepository.Update(commentToUpdate);

            

            return _mapper.Map<CommentDTO>(updatedComment);
        }
    }
}
