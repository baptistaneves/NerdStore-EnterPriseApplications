var builder = WebApplication.CreateBuilder(args);

builder.SetEnvironment();

builder.AddIdentityConfiguration();

builder.AddMvcConfiguration();

builder.RegisterServices();

var app = builder.Build();

app.UseMvcConfiguration();

app.Run();
