using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ArticleProject.Domain.Api;
using ArticleProject.Domain.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleProject.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : Controller
    {
        public ResultModel Result;

        public BaseController()
        {
            Result = ResultModel.Success();
        }

        protected JsonResult OkResponse<T>(T data) where T : class
        {
            var response = Response<T>.Create(HttpStatusCode.OK, data);

            return Json(response);
        }

        protected JsonResult BadResponse<T>(T data) where T : class
        {
            var response = Response<T>.Create(HttpStatusCode.BadRequest, data);

            return Json(response);
        }
    }
}