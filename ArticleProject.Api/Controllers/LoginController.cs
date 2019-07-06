using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleProject.Core.Security;
using ArticleProject.Domain.Api;
using ArticleProject.Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace ArticleProject.Api.Controllers
{

    [AllowAnonymous]
    public class LoginController : BaseController
    {
        private readonly ITokenService _tokenService;
        private readonly IConfiguration configuration;
    

        public LoginController( ITokenService tokenService, IConfiguration iConfig)
        {
            _tokenService = tokenService;
            configuration = iConfig;
        }

        // POST api/login
        [HttpPost]
        public async Task<JsonResult> Login([FromBody] LoginApiRequest model)
        {
            Log.Logger.Information("LoginController - Login Logged");
            if (model.Username == configuration.GetValue<string>("MySettings:UserName") && model.Password == configuration.GetValue<string>("MySettings:Password"))
            {
                var token = _tokenService.GenerateToken(model.Username);

                return OkResponse(token);
            }


            return BadResponse(ResultModel.Error("Kullanıcı adı veya şifre yanlış"));
        }
    }
}