using HW.ApplicationDTOs.AccountDTO;

namespace HW.ApplicationDTOs.UserDTOs;

public class UserInfoDTO : AccountInfoDTO
{
    public required string FirstName { get; set; }
    public required string SecondName { get; set; }
    public string? Patronymic { get; set; }
    public string? Description { get; set; }
}