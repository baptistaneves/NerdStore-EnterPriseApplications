namespace NSE.Identidade.API.Configuration;

public static class IdentityConfig
{
    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentityCore<IdentityUser>()
            .AddErrorDescriber<IdentityMensagensPortugues>()
            .AddSignInManager<SignInManager<IdentityUser>>()
            .AddRoles<IdentityRole>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        var appsettingsSection = configuration.GetSection("AppSettings");
        services.Configure<AppSettings>(appsettingsSection);

        var appSettins = appsettingsSection.Get<AppSettings>();
        var key = Encoding.ASCII.GetBytes(appSettins.Secret);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(bearOptions =>
        {
            bearOptions.RequireHttpsMetadata = true;
            bearOptions.SaveToken = true;
            bearOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = appSettins.ValidoEm,
                ValidIssuer = appSettins.Emissor
            };
        });


        return services;
    }

    public static WebApplication UseIdentityConfiguration(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}


