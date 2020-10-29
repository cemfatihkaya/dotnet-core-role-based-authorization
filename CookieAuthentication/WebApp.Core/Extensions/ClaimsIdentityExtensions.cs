using System.Security.Claims;

namespace WebApp.Core.Extensions
{
    public static class ClaimsIdentityExtensions
    {
        public static string GetClaimValue(this ClaimsIdentity identity, string claimTypeName)
        {
            return identity.FindFirst(claimTypeName).Value;
        }

        public static int GetClaimValueAsInt(this ClaimsIdentity identity, string claimTypeName)
        {
            return GetClaimValue(identity, claimTypeName).ToInt32();
        }

        public static bool GetClaimValueAsBoolean(this ClaimsIdentity identity, string claimTypeName)
        {
            return GetClaimValueAsInt(identity, claimTypeName).ToBoolean();
        }

        public static bool ClaimExists(this ClaimsIdentity identity, string claimTypeName)
        {
            return identity.FindFirst(claimTypeName) != null;
        }
    }

    public static class ClaimsPrincipalExtensions
    {
        public static string GetClaimValue(this ClaimsPrincipal principal, string claimTypeName)
        {
            return principal.FindFirst(claimTypeName).Value;
        }

        public static int GetClaimValueAsInt(this ClaimsPrincipal principal, string claimTypeName)
        {
            return GetClaimValue(principal, claimTypeName).ToInt32();
        }

        public static bool GetClaimValueAsBoolean(this ClaimsPrincipal principal, string claimTypeName)
        {
            return GetClaimValueAsInt(principal, claimTypeName).ToBoolean();
        }
    }
}