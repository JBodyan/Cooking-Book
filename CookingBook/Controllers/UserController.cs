using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Dto.User;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookingBook.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private IUserService UserService { get; }
        private IUserResolverService UserResolverService { get; }

        public UsersController(IUserService userService, IUserResolverService userResolverService)
        {
            UserService = userService;
            UserResolverService = userResolverService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> Get([FromRoute] Guid userId)
        {
            var user = await UserService.GetById(x => x.Id == userId);
            if (user == null)
                return NotFound();
            return user;
        }

        [HttpGet("id")]
        [Authorize]
        public async Task<ActionResult<int>> GetUserId()
        {
            var userId = UserResolverService.GetUserId();
            return Ok(userId);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody]UserUpdateDto user)
        {
            if (id == UserResolverService.GetUserId() || UserResolverService.IsUserAdmin())
            {
                user.Id = id;
                await UserService.UpdateUser(user);
                return NoContent();
            }

            return Forbid();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            //await UserService.RemoveUser(id);
            return Ok();
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody]ResetPasswordDto email)
        {
            await UserService.SendPasswordResetConfirmation(email.Email);
            return Ok();
        }

        [HttpPut("reset-password")]
        public async Task<IActionResult> CreateNewPassword([FromBody]ResetPasswordDto newPassword)
        {
            await UserService.ResetPassword(newPassword);
            return Ok();
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserRegisterDto>> Register([FromBody] UserRegisterDto user)
        {
            try
            {
                var createdUser = await UserService.AddUser(user);
                if (createdUser != null)
                {
                    return CreatedAtAction(nameof(GetUserId), new { id = createdUser.Id }, createdUser);
                }
            }
            catch (Exception e)
            {
                return BadRequest(new{ message = e.Message });
            }
            return BadRequest();
        }
    }
}