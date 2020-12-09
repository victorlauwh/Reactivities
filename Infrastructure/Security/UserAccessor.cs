using System.Linq;
using System.Security.Claims;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Security
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccess;
        public UserAccessor(IHttpContextAccessor httpContextAccess)
        {
            _httpContextAccess = httpContextAccess;
        }

        public string GetCurrentUsername()
        {
            var username= _httpContextAccess.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return username;
        }
    }
}