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
    public class ReplyToCommentCommandHandler : IRequestHandler<ReplyToCommentCommand, BaseCommandResponse<CommentDTO>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public ReplyToCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<CommentDTO>> Handle(ReplyToCommentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<CommentDTO>();

            var validator = new ReplyToCommentDTOValidator();
            var validationResult = await validator.ValidateAsync(request.ReplyToCommentDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Validation failed";
                response.Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return response;
            }

            var comment = _mapper.Map<Comment>(request.ReplyToCommentDTO);
            comment.AuthorID = request.AuthorID;

            // Assuming the repository method for replying to a comment returns the created reply comment
            var replyComment = await _commentRepository.ReplyToComment(comment);

            

            response.Success = true;
            response.Message = "Reply comment created successfully";
            response.Data = _mapper.Map<CommentDTO>(replyComment);

            return response;
        }
    }
}
