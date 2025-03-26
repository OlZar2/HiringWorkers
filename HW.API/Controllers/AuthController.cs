﻿using HW.Application.Services.AuthLogic.Interfaces;
using HW.ApplicationDTOs.AuthDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HW.API.Controllers;

public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register-user")]
    public async Task<Guid> Register([FromBody] UserRegisterDTO userRegisterDTO) => await _authService.RegisterUserAsync(userRegisterDTO);

    [HttpPost("login")]
    public async Task<string> Login([FromBody] LoginDTO loginDTO) => await _authService.LoginAsync(loginDTO);
}
