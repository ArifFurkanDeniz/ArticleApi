using FluentValidation;
using ArticleProject.Domain.Api;
using ArticleProject.Domain.Dto;

namespace ArticleProject.Domain.Validation
{
    public class NewCommentApiRequestValidator : AbstractValidator<NewCommentApiRequest>
    {
        public NewCommentApiRequestValidator()
        {
            RuleFor(m => m.Email)
                .NotEmpty().WithMessage(ValidationMessage.Required)
             .MaximumLength(100).WithMessage(ValidationMessage.MaxLength(100))
             .EmailAddress().WithMessage(ValidationMessage.RequiredEmail);

            RuleFor(m => m.Text)
                .NotEmpty().WithMessage(ValidationMessage.Required);

            RuleFor(m => m.ArticleId)
                .NotEmpty().WithMessage(ValidationMessage.Required);

        }
    }
}
