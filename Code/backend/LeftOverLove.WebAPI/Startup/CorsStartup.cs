namespace LeftOverLove.WebAPI.Startup;

public static class CorsStartup
{
    public static WebApplicationBuilder PrepareCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                        policy.WithOrigins(
                            "http://localhost:5000",
                            "https://localhost:5001",
                            "http://localhost:8100",
                            "https://localhost:8101",
                            "https://{FRONTEND_DOMAIN}"
                        );
                    });
            });


        return builder;
    }

    public static WebApplication ApplyCors(this WebApplication app)
    {
        app.UseCors();

        return app;
    }
}
