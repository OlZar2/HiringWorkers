using System.ComponentModel.DataAnnotations;

namespace HW.ApplicationDTOs.AuthDTOs;

public class UserRegisterDTO
{
    [Required(ErrorMessage = "Email не может быть пустым")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Пароль не может быть пустым")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Имя не может быть пустым")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Фамилия не может быть пустой")]
    public string SecondName { get; set; }

    public string Patronymic { get; set; }

    [Required(ErrorMessage = "Телефон не может быть пустым")]
    public string PhoneNumber { get; set; }
}