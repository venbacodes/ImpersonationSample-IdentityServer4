using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace ImpersonationClient.Pages.Account
{
    [Authorize(Policy = "Impersonate")]
    public class ImpersonateModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ImpersonateModel> _logger;

        [BindProperty]
        public string Email { get; set; }

        public ImpersonateModel(
            IConfiguration configuration,
            ILogger<ImpersonateModel> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(Email))
            {
                _logger.LogDebug($"{User.Identity.Name} tried to impersonate {Email}");

                var returnUrl = $"https://localhost:44332/account/startimpersonation?challenge=true";

                return Redirect($"https://localhost:5002/account/impersonate?email={Email}&returnUrl={returnUrl}");
            }

            ModelState.AddModelError("customError", !string.IsNullOrWhiteSpace(Email) ? $"{Email} cannot be found." : "Valid email is required: ex@abc.xyz");

            return Page();
        }
    }
}
