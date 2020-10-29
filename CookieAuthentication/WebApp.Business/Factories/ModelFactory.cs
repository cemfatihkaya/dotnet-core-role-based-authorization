using WebApp.Business.Abstract;
using WebApp.Model;

namespace WebApp.Business.Factories
{
    public class ModelFactory : IModelFactory
    {
        public AuthenticateModel CreateAuthenticateModel(Users users)
        {
            return new AuthenticateModel
            {
                UserId = users.Id,
                FirstName = users.FirstName,
                LastName = users.LastName,
                EmailAddress = users.EmailAddress,
                Role = users.Role
            };
        }
    }
}