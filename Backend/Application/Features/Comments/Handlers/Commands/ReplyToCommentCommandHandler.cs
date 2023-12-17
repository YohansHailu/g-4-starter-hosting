using MediatR;
using AutoMapper;
using Application.Responses;
using Domain;
using Application.DTOs.Comment;
using Application.DTOs.Comment.Validators;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Comments.Requests.Commands;
using Application.Contracts;

namespace Application.Features.Comments.Handlers.Commands
{
    public class ReplyToCommentCommandHandler : IRequestHandler<ReplyToCommentCommand, CommentDTO>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public ReplyToCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CommentDTO> Handle(ReplyToCommentCommand request, CancellationToken cancellationToken)
        {

            var validator = new ReplyToCommentDTOValidator();
            var validationResult = await validator.ValidateAsync(request.ReplyToCommentDTO);

            if (!validationResult.IsValid)
            {
                return null;
            }

            var comment = _mapper.Map<Comment>(request.ReplyToCommentDTO);
            // Assume the repository method for replying to a comment returns the created reply comment
            var replyComment = await _commentRepository.ReplyToComment(comment);

            

            return _mapper.Map<CommentDTO>(replyComment);
        }
    }
}
