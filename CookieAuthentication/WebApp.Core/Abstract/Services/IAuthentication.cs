using System.Security.Claims;

namespace WebApp.Core.Abstract
{
    public interface IAuthentication
    {
        ClaimsPrincipal GetSessionUser();

        bool IsSessionUserAuthenticated();
    }
}