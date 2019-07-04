using FluentValidation;
using ArticleProject.Domain.Api;

namespace ArticleProject.Domain.Validation
{
    public class LoginApiRequestValidator : AbstractValidator<LoginApiRequest>
    {
        public LoginApiRequestValidator()
        {
            RuleFor(m => m.Username)
                .NotEmpty().WithMessage(ValidationMessage.Required);

            RuleFor(m => m.Password)
                .NotEmpty().WithMessage(ValidationMessage.Required);

        }
    }
}
