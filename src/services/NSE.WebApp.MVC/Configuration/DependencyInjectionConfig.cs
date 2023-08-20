namespace NSE.WebApp.MVC.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.TryAddScoped<IUser, AspNetUser>();
    }
}
