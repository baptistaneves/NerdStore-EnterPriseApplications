var builder = WebApplication.CreateBuilder(args);

builder.SetEnvironment();

builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.AddApiConfiguration();

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseSwaggerConfiguration();

app.UseApiConfiguration();

app.Run();
