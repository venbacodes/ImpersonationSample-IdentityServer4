using System;
using System.Linq;
using System.Security.Claims;

namespace IdentityServer
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsImpersonating(this ClaimsPrincipal principal)
        {
            return principal.HasClaim(c =>
                                            c.Type.Equals("IsImpersonating", StringComparison.OrdinalIgnoreCase) &&
                                            c.Value.Equals("True", StringComparison.OrdinalIgnoreCase));
        }

        public static bool HasRole(this ClaimsPrincipal principal, string role)
        {
            return principal.HasClaim(c =>
                                            c.Type == ClaimTypes.Role &&
                                            c.Value.Equals(role, StringComparison.OrdinalIgnoreCase));
        }

        public static T GetClaim<T>(this ClaimsPrincipal principal, string claim)
        {
            var result = principal?.Claims?.FirstOrDefault(f => f.Type.Equals(claim, StringComparison.OrdinalIgnoreCase))?.Value;

            return (T)Convert.ChangeType(result, typeof(T));
        }
    }
}
