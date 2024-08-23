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
                            "http://localhost:5173"
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