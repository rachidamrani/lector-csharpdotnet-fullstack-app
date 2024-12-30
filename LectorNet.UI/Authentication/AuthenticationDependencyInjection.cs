namespace LectorNet.UI.Authentication;

public static class AuthenticationDependencyInjection
{
    public static IServiceCollection AddBlazorAppAuthentication(this IServiceCollection services)
    {
        services
            .AddAuthentication(AuthConstants.AuthScheme)
            .AddCookie(
                AuthConstants.AuthScheme,
                options =>
                {
                    options.Cookie.Name = AuthConstants.AuthCookie;
                    options.LoginPath = "/auth/login";
                    options.AccessDeniedPath = "/auth/access-denied";
                    options.LogoutPath = "/auth/logout";

                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.Strict;

                    options.ExpireTimeSpan = TimeSpan.FromDays(1);
                    options.SlidingExpiration = true;
                }
            );

        services.AddScoped<AuthService>();

        return services;
    }
}
