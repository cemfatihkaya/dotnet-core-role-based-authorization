using WebApp.Model;

namespace WebApp.Business.Abstract
{
    public interface IModelFactory
    {
        AuthenticateModel CreateAuthenticateModel(Users users);
    }
}