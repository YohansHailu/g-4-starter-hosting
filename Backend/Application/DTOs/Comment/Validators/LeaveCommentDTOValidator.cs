using Application.DTOs.Comment;
using FluentValidation;

namespace Application.DTOs.Comment.Validators
{
    public class LeaveCommentDTOValidator : AbstractValidator<LeaveCommentDTO>
    {
        public LeaveCommentDTOValidator()
        {
            RuleFor(dto => dto.ArticleID)
                .NotEmpty().WithMessage("ArticleID is required.");

            RuleFor(dto => dto.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MaximumLength(500).WithMessage("Content cannot exceed 500 characters.");
        }
    }
}




