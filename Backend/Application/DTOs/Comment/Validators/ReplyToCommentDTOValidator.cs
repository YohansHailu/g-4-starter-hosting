using Application.DTOs.Comment;
using FluentValidation;

namespace Application.DTOs.Comment.Validators
{
    public class ReplyToCommentDTOValidator : AbstractValidator<ReplyToCommentDTO>
    {
        public ReplyToCommentDTOValidator()
        {
            RuleFor(dto => dto.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MaximumLength(500).WithMessage("Content cannot exceed 500 characters.");

            RuleFor(dto => dto.ParentCommentID)
                .NotEmpty().WithMessage("ParentCommentID is required.");
        }
    }
}
