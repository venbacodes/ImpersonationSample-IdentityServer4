using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ImpersonationClient.Pages
{
    public class LoginModel : PageModel
    {
        public IActionResult OnGet()
        {

            return Challenge(
                new AuthenticationProperties()
                {
                    RedirectUri = "/"                    
                },
                OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}