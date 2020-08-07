using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Dto;
using Application.Dto.User;
using Application.Services.Interfaces;
using CookingBook.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CookingBook.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : Controller
    {

        private readonly ITokenService _tokenService;
        private readonly IUserResolverService _userResolverService;
        public LoginController(ITokenService tokenService, IUserResolverService userResolverService)
        {
            _tokenService = tokenService;
            _userResolverService = userResolverService;
        }

        [HttpPost("sign-in")]
        [AuthorizationFilter]
        public async Task<ActionResult<UserTokenDto>> SignIn([FromBody]SignInDto model)
        {
            var user = await _tokenService.VerifyUserCredentials(model);

            var claims = new[]
            {
                new Claim("id",user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,user.Role.Name)
            };
            var jwt = _tokenService.GenerateJwt(claims);
            var refreshToken = await _tokenService.GenerateRefreshToken(user);

            var userTokenDto = new UserTokenDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role.Name,
                Token = new TokenDto { JWT = jwt, RefreshToken = refreshToken }
            };

            return Ok(userTokenDto);
        }

        [HttpPost("refresh")]
        [AuthorizationFilter]
        public async Task<ActionResult<UserTokenDto>> Refresh([FromBody] TokenDto refreshTokenModel)
        {
            var refresh = await _tokenService.VerifyRefreshToken(refreshTokenModel.RefreshToken);

            var claims = _tokenService.GetPrincipalFromExpiredToken(refreshTokenModel.JWT);
            var jwt = _tokenService.GenerateJwt(claims.Claims);
            var refreshToken = await _tokenService.UpdateRefreshRecord(refresh);

            var userToken = new UserTokenDto
            {
                Id = refresh.User.Id,
                FirstName = refresh.User.FirstName,
                LastName = refresh.User.LastName,
                Role = refresh.User.Role.Name,
                Token = new TokenDto { JWT = jwt, RefreshToken = refreshToken }
            };
            return Ok(userToken);
        }


    }
}