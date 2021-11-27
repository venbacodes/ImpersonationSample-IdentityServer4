using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ImpersonationClient.Pages.Account
{
    [Authorize(Policy = "EndImpersonate")]
    public class EndImpersonationModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Challenge(new AuthenticationProperties() { RedirectUri = "/" }, OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}
