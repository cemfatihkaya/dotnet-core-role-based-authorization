namespace WebApp.Model
{
    public class IdentityUser
    {
        public int UserId { get; set; }

        public string MemberSecureId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Role { get; set; }

        public string MemberFullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}