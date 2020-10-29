namespace WebApp.Model
{
    public static class DefaultAuthenticationTypes
    {
        //
        // Summary:
        //     Default value for the main application cookie used by UseSignInCookies
        public static string ApplicationCookie => nameof(ApplicationCookie);

        //
        // Summary:
        //     Default value used for the ExternalSignInAuthenticationType configured by UseSignInCookies
        public static string ExternalCookie => nameof(ExternalCookie);

        //
        // Summary:
        //     Default value used by the UseOAuthBearerTokens method
        public static string ExternalBearer => nameof(ExternalBearer);

        //
        // Summary:
        //     Default value for authentication type used for two factor partial sign in
        public static string TwoFactorCookie => nameof(TwoFactorCookie);

        //
        // Summary:
        //     Default value for authentication type used for two factor remember browser
        public static string TwoFactorRememberBrowserCookie => "TwoFactorRememberBrowser";
    }

    public static class ClaimTypeNames
    {
        public static string MemberId => "member_id";

        public static string FirstName => "first_name";

        public static string LastName => "last_name";

        public static string IdentityProvider => "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/IdentityProvider";
    }

    public static class DefaultClaimTypeValues
    {
        public static string IdentityProviderValue => "WebApp Identity";
    }
}