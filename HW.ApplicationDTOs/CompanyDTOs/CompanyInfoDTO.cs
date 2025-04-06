namespace HW.ApplicationDTOs.CompanyDTOs;

using HW.ApplicationDTOs.AccountDTO;

public class CompanyInfoDTO : AccountInfoDTO
{
    public required string CompanyName { get; set; }
    public string? Description { get; set; }
}