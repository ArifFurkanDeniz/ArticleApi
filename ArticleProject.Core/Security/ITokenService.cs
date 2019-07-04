using System.Collections.Generic;
using System.Security.Claims;
using ArticleProject.Domain.Api;
using ArticleProject.Domain.Dto;

namespace ArticleProject.Core.Security
{
    public interface ITokenService
    {
        TokenApiResponse GenerateToken(string username);

        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
    }
}
