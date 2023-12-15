using Application.DTOs.Comment;
using FluentValidation;

namespace Application.DTOs.Comment.Validators
{
    public class UpdateCommentDTOValidator : AbstractValidator<UpdateCommentDTO>
    {
        public UpdateCommentDTOValidator()
        {
            RuleFor(dto => dto.ID)
                .NotEmpty().WithMessage("CommentID is required.");

            RuleFor(dto => dto.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MaximumLength(500).WithMessage("Content cannot exceed 500 characters.");
        }
    }
}
