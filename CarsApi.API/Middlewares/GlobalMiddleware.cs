using System.Net;
using System.Text.Json;

public class GlobalMiddleware
{
    private readonly RequestDelegate _next;
    public GlobalMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // chama o próximo middleware/controlador
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode status = HttpStatusCode.InternalServerError; // 500 por padrão
        string message = exception.Message;

        // Mapear exceções específicas para status HTTP
        switch (exception)
        {
            case ArgumentNullException:
            case ArgumentException:
                status = HttpStatusCode.BadRequest; // 400
                break;
            case KeyNotFoundException:
                status = HttpStatusCode.NotFound; // 404
                break;
            case UnauthorizedAccessException:
                status = HttpStatusCode.Unauthorized; // 401
                break;
            case NotImplementedException:
                status = HttpStatusCode.NotImplemented; // 501
                break;
            // Adicione outros casos que desejar
        }

        var response = new
        {
            status = (int)status,
            error = message
        };

        string json = JsonSerializer.Serialize(response);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;

        return context.Response.WriteAsync(json);
    }
}
