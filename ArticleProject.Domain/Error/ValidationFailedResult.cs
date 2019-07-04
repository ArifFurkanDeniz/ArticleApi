using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ArticleProject.Domain.Api;

namespace ArticleProject.Domain.Error
{
    public class ValidationFailedResult : ObjectResult
    {
        public ValidationFailedResult(ModelStateDictionary modelState) : base(Response<ValidationError>.ValidError(modelState))
        {
            StatusCode = StatusCodes.Status200OK;
        }
    }
}
