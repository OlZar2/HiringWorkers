using System.ComponentModel.DataAnnotations;

namespace HW.ApplicationDTOs.AuthDTOs;

public class CompanyRegisterDTO
{
    [Required(ErrorMessage = "Email не может быть пустым")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Пароль не может быть пустым")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Имя компании быть пустым")]
    public string CompanyName { get; set; }

    [Required(ErrorMessage = "Телефон не может быть пустым")]
    public string PhoneNumber { get; set; }
}
