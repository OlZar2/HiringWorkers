using HW.API.Errors.Models;
using HW.API.Responses;
using HW.Application.Services.AuthLogic.Interfaces;
using HW.ApplicationDTOs.AuthDTOs;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HW.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register-user")]
    [SwaggerResponse(401, "Аккаунт уже зарегестрирован", typeof(SimpleErrorModel))]
    [SwaggerResponse(400, "Ошибка валидации", typeof(HttpValidationProblemDetails))]
    [SwaggerResponse(500, "Ошибка сервера", typeof(SimpleErrorModel))]
    [SwaggerResponse(200, "Ок", typeof(UserIdResponse))]
    public async Task<UserIdResponse> RegisterUser([FromBody] UserRegisterDTO userRegisterDTO)
    {
        var userId = await _authService.RegisterUserAsync(userRegisterDTO);
        return new UserIdResponse{ UserId = userId };
    }

    [HttpPost("login")]
    [SwaggerResponse(401, "Неверный логин/пароль", typeof(SimpleErrorModel))]
    [SwaggerResponse(400, "Ошибка валидации", typeof(HttpValidationProblemDetails))]
    [SwaggerResponse(500, "Ошибка сервера", typeof(SimpleErrorModel))]
    [SwaggerResponse(200, "Ок", typeof(JwtResponse))]
    public async Task<JwtResponse> Login([FromBody] LoginDTO loginDTO) {
        var token = await _authService.LoginAsync(loginDTO);
        return new JwtResponse { Token = token };
    }

    [HttpPost("register-company")]
    [SwaggerResponse(401, "Неверный логин/пароль", typeof(SimpleErrorModel))]
    [SwaggerResponse(400, "Ошибка валидации", typeof(HttpValidationProblemDetails))]
    [SwaggerResponse(500, "Ошибка сервера", typeof(SimpleErrorModel))]
    [SwaggerResponse(200, "Ок", typeof(UserIdResponse))]
    public async Task<UserIdResponse> RegisterCompany([FromBody] CompanyRegisterDTO companyRegisterDTO)
    {
        var userId = await _authService.RegisterCompanyAsync(companyRegisterDTO);
        return new UserIdResponse{ UserId = userId };
    }
}
