using HW.Application.Services.AuthLogic.Exceptions;
using HW.Persistence.Repositories.Exceptions;
using System.Text.Json;

namespace HW.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException e)
        {
            if (context.Request.Path.StartsWithSegments("/auth/login"))
            {
                await WriteErrorResponse(context, StatusCodes.Status401Unauthorized, "Неверный email или пароль.");
            }
            else
            {
                await WriteErrorResponse(context, StatusCodes.Status404NotFound, e.Message);
            }
        }
        catch (WrongPasswordException)
        {
            await WriteErrorResponse(context, StatusCodes.Status401Unauthorized, "Неверный email или пароль.");
        }
        catch (ExistingUserException)
        {
            await WriteErrorResponse(context, StatusCodes.Status401Unauthorized, "Пользователь с таким email уже существует");
        }
        catch (ArgumentException e)
        {
            await WriteErrorResponse(context, StatusCodes.Status400BadRequest, e.Message);
        }
    }

    private async Task WriteErrorResponse(HttpContext context, int statusCode, string message)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";
        var result = JsonSerializer.Serialize(new { message });
        await context.Response.WriteAsync(result);
    }
}
