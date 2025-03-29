using HW.Application.Services.AuthLogic.Interfaces;
using HW.ApplicationDTOs.AuthDTOs;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<Guid> RegisterUser([FromBody] UserRegisterDTO userRegisterDTO) => await _authService.RegisterUserAsync(userRegisterDTO);

    [HttpPost("login")]
    public async Task<string> Login([FromBody] LoginDTO loginDTO) => await _authService.LoginAsync(loginDTO);

    [HttpPost("register-company")]
    public async Task<Guid> RegisterCompany([FromBody] CompanyRegisterDTO companyRegisterDTO) 
        => await _authService.RegisterCompanyAsync(companyRegisterDTO);
}
