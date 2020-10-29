namespace WebApp.Model
{
    public class AuthenticateModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Role { get; set; }
    }
}