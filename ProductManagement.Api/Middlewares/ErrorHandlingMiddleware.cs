using System.Net;
using System.Text.Json;

public sealed class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var problem = new
            {
                traceId = context.TraceIdentifier,
                status = context.Response.StatusCode,
                title = "An unexpected error occurred",
                detail = ex.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
        }
    }
}
