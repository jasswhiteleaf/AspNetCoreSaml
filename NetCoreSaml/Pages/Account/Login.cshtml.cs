using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MainApp.Model;
using Sustainsys.Saml2.AspNetCore2;

namespace MainApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        public IActionResult OnGet(string returnUrl)
        {
            returnUrl ??= "/Main/Index";
            if (!Url.IsLocalUrl(returnUrl))
            {
                throw new InvalidOperationException("Open redirect protection");
            }

            var props = new AuthenticationProperties
            {
                RedirectUri = "/Account/Consume",
                Items = { { "returnUrl", returnUrl } }
            };

            return Challenge(props, Saml2Defaults.Scheme);
        }

        [BindProperty]
        public LoginInfo LoginInfo { get; set; }
    }
}
