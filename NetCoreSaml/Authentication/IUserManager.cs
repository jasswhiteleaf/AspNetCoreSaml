using MainApp.Model;

namespace MainApp.Authentication
{
    public interface IUserManager
    {
        Task SignIn(HttpContext httpContext, LoginInfo loginInfo, bool isPersistent = false);
        Task SignOut(HttpContext httpContext);
    }
}
