using HW.ApplicationDTOs.AccountDTO;

namespace HW.ApplicationDTOs.UserDTOs;

public class UserPatchDTO : AccountPatchDTO
{
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? Patronymic { get; set; }
    public string? Description { get; set; }
}
