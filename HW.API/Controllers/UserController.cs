using HW.API.Errors.Models;
using HW.API.Filters;
using HW.API.Filters.Attributes;
using HW.Application.Services.AuthLogic.Interfaces;
using HW.Application.Services.UserLogic.Interfaces;
using HW.ApplicationDTOs.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HW.API.Controllers;

[ApiController]
[Authorize]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{userId}")]
    [SwaggerResponse(200, "Ок", typeof(UserInfoDTO))]
    [SwaggerResponse(401, "Не авторизован")]
    [SwaggerResponse(403, "Нет прав")]
    [SwaggerResponse(404, "Не найден", typeof(SimpleErrorModel))]
    [SwaggerResponse(500, "Ошибка сервера", typeof(SimpleErrorModel))]
    public async Task<UserInfoDTO> GetUserInfo(Guid userId) => await _userService.GetUserInfoAsync(userId);

    [HttpPatch("{userId}")]
    [CanChangeAccount]
    [SwaggerResponse(200, "Ок", typeof(UserInfoDTO))]
    [SwaggerResponse(401, "Не авторизован")]
    [SwaggerResponse(403, "Нет прав")]
    [SwaggerResponse(404, "Не найден", typeof(SimpleErrorModel))]
    [SwaggerResponse(500, "Ошибка сервера", typeof(SimpleErrorModel))]
    public async Task<UserInfoDTO> PatchUserInfo([FromBody] UserPatchDTO patchUserInfo, Guid userId) =>
        await _userService.PatchUserInfoAsync(patchUserInfo, userId);
}