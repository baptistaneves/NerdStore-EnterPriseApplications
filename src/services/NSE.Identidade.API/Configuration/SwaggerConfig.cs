namespace NSE.Identidade.API.Configuration;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "NerdStore Enterprise Identinty API",
                Description = "Está API faz parte do curso ASP .NET Core Enterprise Applications.",
                Contact = new OpenApiContact() { Name = "Baptista Neves", Email = "baptistafirminoneves@gmail.com" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });
        });

        return services;
    }

    public static WebApplication UseSwaggerConfiguration(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }

        return app;
    }
}


