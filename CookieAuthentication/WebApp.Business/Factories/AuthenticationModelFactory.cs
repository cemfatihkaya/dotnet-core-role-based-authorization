using System.Collections.Generic;
using System.Security.Claims;
using WebApp.Business.Abstract;
using WebApp.Model;

namespace WebApp.Business.Factories
{
    public class AuthenticationModelFactory : IAuthenticationModelFactory
    {
        public ClaimsIdentity CreateClaimsIdentityFromMember(AuthenticateModel member)
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, member.EmailAddress),
                new Claim(ClaimTypeNames.IdentityProvider, DefaultClaimTypeValues.IdentityProviderValue),
                new Claim(ClaimTypes.Email, member.EmailAddress),
                new Claim(ClaimTypes.Name, $"{member.FirstName} {member.LastName}"),
                new Claim(ClaimTypeNames.MemberId, member.UserId.ToString()),
                new Claim(ClaimTypeNames.FirstName, member.FirstName),
                new Claim(ClaimTypeNames.LastName, member.LastName),
                new Claim(ClaimTypes.Role, member.Role),
            };

            return new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}