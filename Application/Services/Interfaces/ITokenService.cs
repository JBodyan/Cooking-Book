using Data.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;

namespace Application.Services.Interfaces
{
    public interface ITokenService
    {
        Task<User> VerifyUserCredentials(SignInDto model);

        Task<RefreshToken> VerifyRefreshToken(string token);

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

        Task<string> GenerateRefreshToken(User user);

        Task<string> UpdateRefreshRecord(RefreshToken refreshToken);

        string GenerateJwt(IEnumerable<Claim> claims);
    }
}
