using HW.ApplicationDTOs.AccountDTO;

namespace HW.ApplicationDTOs.CompanyDTOs;

public class CompanyPatchDTO : AccountPatchDTO
{
    public string? CompanyName { get; set; }
    public string? Description { get; set; }
}
