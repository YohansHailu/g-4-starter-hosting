using AutoMapper;
using FluentValidation;
using Application.DTOs.Comment;
using Application.DTOs.Comment.Validators;
using Application.Responses;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Comments.Requests.Commands;
using Application.Contracts;

namespace Application.Features.Comments.Handlers.Commands
{
    public class LeaveCommentCommandHandler : IRequestHandler<LeaveCommentCommand, BaseCommandResponse<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public LeaveCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Guid>> Handle(LeaveCommentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Guid>();

            var validator = new LeaveCommentDTOValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveCommentDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Validation failed";
                response.Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return response;
            }

            var comment = _mapper.Map<Comment>(request.LeaveCommentDTO);

            // Assign comment's AuthorId based on the request
            comment.AuthorID = request.AuthorID;

            comment = await _commentRepository.Add(comment);

            response.Success = true;
            response.Message = "Comment created successfully";
            response.ID = comment.ID;

            return response;
        }
    }
}
