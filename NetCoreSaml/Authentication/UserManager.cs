using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using MainApp.Model;

namespace MainApp.Authentication
{
    public class UserManager : IUserManager
    {
        public UserManager() 
        {
        }

        public async Task SignIn(HttpContext httpContext, LoginInfo loginInfo, bool isPersistent = false)
        {
            //using (var con = new SqlConnection(_connectionString))
            //{
            var successUser = loginInfo; // change this

            ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(successUser), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            //}
        }

        public async Task SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        private IEnumerable<Claim> GetUserClaims(LoginInfo user) // change this model to match our authentication model
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.EmailAddress));
            claims.Add(new Claim(ClaimTypes.Role, "BugHunter"));
            return claims;
        }
    }
}
