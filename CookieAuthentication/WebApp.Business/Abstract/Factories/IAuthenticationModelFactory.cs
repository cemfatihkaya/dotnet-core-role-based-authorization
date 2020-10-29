using System.Security.Claims;
using WebApp.Model;

namespace WebApp.Business.Abstract
{
    public interface IAuthenticationModelFactory
    {
        ClaimsIdentity CreateClaimsIdentityFromMember(AuthenticateModel member);
    }
}