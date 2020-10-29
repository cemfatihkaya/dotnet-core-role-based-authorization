using System.Security.Claims;

namespace WebApp.Business.Abstract
{
    public interface IAuthenticationService
    {
        ClaimsIdentity AuthenticateMemberByEmail(string emailAddress, string password);

        ClaimsPrincipal GetSessionUser();

        bool IsSessionUserAuthenticated();
    }
}