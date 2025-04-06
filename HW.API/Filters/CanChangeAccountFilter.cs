using HW.Application.Services.AuthLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HW.API.Filters;

public class CanChangeAccountFilter : IAsyncActionFilter
{
    private readonly IAuthService _authService;

    public CanChangeAccountFilter(IAuthService userAccessService)
    {
        _authService = userAccessService;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var userIdFromRoute = context.ActionArguments["userId"]?.ToString();

        if (userIdFromRoute == null)
        {
            context.Result = new BadRequestObjectResult("Не найден Id пользователя в запросе");
            return;
        }

        var currentUserId = context.HttpContext.User?.Claims
            .FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (Guid.TryParse(userIdFromRoute, out Guid userGuid) &&
            Guid.TryParse(currentUserId, out Guid currentGuid))
        {
            bool hasAccess = _authService.CanChangeAccountInfo(currentGuid, userGuid);
            if (!hasAccess)
            {
                context.Result = new ForbidResult("Вы можете изменять только свой аккаунт.");
                return;
            }
        }
        else
        {
            context.Result = new BadRequestObjectResult("Неверный формат Id");
            return;
        }

        await next();
    }
}
