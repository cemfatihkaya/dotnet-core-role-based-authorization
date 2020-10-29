using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using WebApp.Core.Abstract;

namespace WebApp.Core.Services
{
    public class CookieAuthenticationService : IAuthentication
    {
        #region ctor

        readonly IHttpContextAccessor httpContextAccessor;

        public CookieAuthenticationService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        #endregion

        public ClaimsPrincipal GetSessionUser()
        {
            var user = httpContextAccessor.HttpContext.User;

            return user ?? null;
        }

        public bool IsSessionUserAuthenticated()
        {
            return httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}