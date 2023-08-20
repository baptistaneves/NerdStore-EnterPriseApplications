namespace NSE.WebApp.MVC.Configuration;

public static class IdentityConfig
{
    public static void AddIdentityConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/login";
                options.AccessDeniedPath= "/acesso-negado";
            });
    }

    public static void UseIdentityConfiguration(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}
