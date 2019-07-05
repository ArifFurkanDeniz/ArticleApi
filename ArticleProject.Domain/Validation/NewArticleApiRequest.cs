using FluentValidation;
using ArticleProject.Domain.Api;
using ArticleProject.Domain.Dto;

namespace ArticleProject.Domain.Validation
{
    public class NewArticleApiRequestValidator : AbstractValidator<NewArticleApiRequest>
    {
        public NewArticleApiRequestValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty().WithMessage(ValidationMessage.Required)
             .MaximumLength(300).WithMessage(ValidationMessage.MaxLength(300));

            RuleFor(m => m.Text)
                .NotEmpty().WithMessage(ValidationMessage.Required);

            RuleFor(m => m.CategoryId)
                .NotEmpty().WithMessage(ValidationMessage.Required);

        }
    }
}
