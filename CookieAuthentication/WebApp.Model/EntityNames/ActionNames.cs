namespace WebApp.Model
{
    public class ActionNames
    {
        public static string Index => nameof(Index).ToLowerInvariant();
        public static string Login => nameof(Login).ToLowerInvariant();
        public static string LogOut => nameof(LogOut).ToLowerInvariant();
        public static string UserAccessDenied => nameof(UserAccessDenied).ToLowerInvariant();
    }
}