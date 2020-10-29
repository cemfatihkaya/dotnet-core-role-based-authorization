using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using WebApp.Business.Abstract;
using WebApp.Core.Abstract;
using WebApp.Model;

namespace WebApp.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        readonly IAuthentication authentication;
        readonly IAuthenticationModelFactory authenticationModelFactory;
        readonly IModelFactory modelFactory;

        public AuthenticationService(
            IAuthentication authentication,
            IAuthenticationModelFactory authenticationModelFactory,
            IModelFactory modelFactory)
        {
            this.authentication = authentication;
            this.authenticationModelFactory = authenticationModelFactory;
            this.modelFactory = modelFactory;
        }

        public ClaimsIdentity AuthenticateMemberByEmail(string emailAddress, string password)
        {
            var user = GetUsers().FirstOrDefault(x => x.EmailAddress == emailAddress);
            if (user == null)
            {
                return null;
            }

            var authModel = modelFactory.CreateAuthenticateModel(user);

            return AuthenticateMember(authModel);
        }

        ClaimsIdentity AuthenticateMember(AuthenticateModel member)
        {
            return authenticationModelFactory.CreateClaimsIdentityFromMember(member);
        }

        public ClaimsPrincipal GetSessionUser()
        {
            var user = authentication.GetSessionUser();

            return user ?? null;
        }

        public bool IsSessionUserAuthenticated()
        {
            return authentication.IsSessionUserAuthenticated();
        }

        static IEnumerable<Users> GetUsers()
        {
            var adminUser = new Users
            {
                Id = 101,
                FirstName = "Admin",
                LastName = "Admin",
                EmailAddress = "admin@test.com",
                Password = "admin",
                Role = "Admin"
            };
            var customerUser = new Users
            {
                Id = 102,
                FirstName = "Customer",
                LastName = "Customer",
                EmailAddress = "customer@test.com",
                Password = "customer",
                Role = "Customer"
            };

            return new List<Users> { adminUser, customerUser };
        }
    }
}