# ImpersonationSample-IdentityServer4

This is a sample application to show a way to implement impersonation when using Identity Server.

**Key Points**

1. Authorization policy has been setup to restrict impersonation to users with specific role.
2. Admin users' email is added as a claim while impersonating so that it can be used while ending the impersonation.
3. Logic is simple as authenticating with the victim users' email for impersonation with additional claims for
