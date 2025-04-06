using HW.ApplicationDTOs.Attributes;
using System.ComponentModel.DataAnnotations;

namespace HW.ApplicationDTOs.AuthDTOs;

public class CompanyRegisterDTO
{
    [Required(ErrorMessage = "Email не может быть пустым")]
    [EmailAddress(ErrorMessage = "Некорректный формат email")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Пароль не может быть пустым")]
    public required string Password { get; set; }

    [Required(ErrorMessage = "Имя компании быть пустым")]
    public required string CompanyName { get; set; }

    [Required(ErrorMessage = "Телефон не может быть пустым")]
    [RussianPhone(ErrorMessage = "Неверный формат телефона")]
    public required string PhoneNumber { get; set; }
}
