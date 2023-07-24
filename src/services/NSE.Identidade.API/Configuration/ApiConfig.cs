namespace NSE.Identidade.API.Configuration;

public static class ApiConfig
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();

        return services;
    }

    public static WebApplication UseApiConfiguration(this WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseIdentityConfiguration();

        app.MapControllers();

        return app;
    }
}


