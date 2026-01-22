namespace Api.Middlewares;

public sealed class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, ILogger<ExceptionMiddleware> logger)
    {
        try
        {
            await next(context);
        }

        catch (OperationCanceledException) { }

        catch (Exception ex)
        {
            logger.LogInformation(ex, "Exception Capturada");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new { message = "Erro interno no servidor. Tente novamente mais tarde." };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}