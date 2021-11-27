using IdentityModel;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AppClaimsPrincipalFactory(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            var roles = await _userManager.GetRolesAsync(user);

            ((ClaimsIdentity)principal.Identity).AddClaims(
                new[] {
                    new Claim(JwtClaimTypes.Subject, user.Id),
                    new Claim(JwtClaimTypes.PreferredUserName, user.UserName),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                });

            ((ClaimsIdentity)principal.Identity).AddClaims(roles.Select(s => new Claim("role", s ?? string.Empty)));

            return principal;
        }
    }
}
