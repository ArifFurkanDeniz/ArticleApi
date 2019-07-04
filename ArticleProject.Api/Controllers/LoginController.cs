using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleProject.Core.Security;
using ArticleProject.Domain.Api;
using ArticleProject.Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArticleProject.Api.Controllers
{

    [AllowAnonymous]
    public class LoginController : BaseController
    {
        private readonly ITokenService _tokenService;
    

        public LoginController( ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        // POST api/login
        [HttpPost]
        public async Task<JsonResult> Login([FromBody] LoginApiRequest model)
        {

            if (model.Username == "username" && model.Password == "password")
            {
                var token = _tokenService.GenerateToken(model.Username);

                return OkResponse(token);
            }


            return BadResponse(ResultModel.Error("Kullanıcı adı veya şifre yanlış"));
        }
    }
}