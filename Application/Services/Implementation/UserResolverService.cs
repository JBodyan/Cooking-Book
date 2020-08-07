using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Implementation
{
    public class UserResolverService : IUserResolverService
    {
        private readonly IHttpContextAccessor _context;
        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public IEnumerable<Claim> GetClaims()
        {
            return _context.HttpContext.User.Claims;
        }

        public Guid GetUserId()
        {
            var claimsIdentity = _context.HttpContext.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity?.FindFirst("id")?.Value;
            return Guid.Parse(userId ?? throw new InvalidOperationException("Id cannot be null"));
        }

        public bool IsUserAdmin()
        {
            return _context.HttpContext.User.IsInRole("Admin");
        }


    }
}
