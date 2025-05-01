using HW.API.Errors.Models;
using HW.Application.Services.AuthLogic.Exceptions;
using HW.Application.Services.SharedLogic.Exceptions;
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
                await WriteErrorResponseAsync(context, StatusCodes.Status401Unauthorized, "Неверный email или пароль.");
            }
            else
            {
                await WriteErrorResponseAsync(context, StatusCodes.Status404NotFound, e.Message);
            }
        }
        catch (NotEnoughRightsException e)
        {
            await WriteErrorResponseAsync(context, StatusCodes.Status403Forbidden, e.Message);
        }
        catch (WrongPasswordException)
        {
            await WriteErrorResponseAsync(context, StatusCodes.Status401Unauthorized, "Неверный email или пароль.");
        }
        catch (ExistingUserException)
        {
            await WriteErrorResponseAsync(context, StatusCodes.Status400BadRequest, "Пользователь с таким email уже существует");
        }
        catch (WrongDataException e)
        {
            await WriteErrorResponseAsync(context, StatusCodes.Status400BadRequest, e.Message);
        }
        catch (ArgumentException e)
        {
            await WriteErrorResponseAsync(context, StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    private async Task WriteErrorResponseAsync(HttpContext context, int statusCode, string message)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";
        var result = JsonSerializer.Serialize(new SimpleErrorModel{ Message=message });
        await context.Response.WriteAsync(result);
    }
}
