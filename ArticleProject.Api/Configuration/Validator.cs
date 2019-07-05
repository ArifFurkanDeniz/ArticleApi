using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ArticleProject.Domain.Api;
using ArticleProject.Domain.Validation;

namespace ArticleProject.Api.Configuration
{
    public static class Validator
    {
        public static void AddMyValidator(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<LoginApiRequest>, LoginApiRequestValidator>();
            services.AddSingleton<IValidator<NewArticleApiRequest>, NewArticleApiRequestValidator>();
            services.AddSingleton<IValidator<NewCommentApiRequest>, NewCommentApiRequestValidator>();
        }
    }
}
