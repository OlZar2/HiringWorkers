﻿using System.ComponentModel.DataAnnotations;

namespace HW.ApplicationDTOs.AuthDTOs;

public class LoginDTO
{
    [Required(ErrorMessage = "Email не может быть пустым")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Пароль не может быть пустым")]
    public string Password { get; set; }
}
