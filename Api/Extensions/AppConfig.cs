using Api.Middlewares;

namespace Api.Extensions;

public static partial class Inject
{
    extension(WebApplication app)
    {
        public WebApplication ApplyConfig()
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<ExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerUI();
                app.UseSwagger();
            }

            app.UseHealthChecks("/v1/health");

            app.UseAuthentication();

            app.MapControllers();

            return app;
        }
    }
}