namespace NSE.Identidade.API.Configuration;

public static class EnvironmentConfig
{
    public static WebApplicationBuilder SetEnvironment(this WebApplicationBuilder builder)
    {
        builder.Configuration.SetBasePath(builder.Environment.ContentRootPath);
        builder.Configuration.AddJsonFile("appsettings.json", true, true);
        builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);
        builder.Configuration.AddEnvironmentVariables();

        if (builder.Environment.IsDevelopment())
        {
            builder.Configuration.AddUserSecrets<StartupBase>();
        }

        return builder;
    }
}
