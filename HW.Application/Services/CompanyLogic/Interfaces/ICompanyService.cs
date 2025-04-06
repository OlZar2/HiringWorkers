using HW.ApplicationDTOs.CompanyDTOs;

namespace HW.Application.Services.CompanyLogic.Interfaces;

public interface ICompanyService
{
    Task<CompanyInfoDTO> GetCompanyInfoAsync(Guid userId);
    Task<CompanyInfoDTO> PatchCompanyInfoAsync(CompanyPatchDTO patchCompanyInfo, Guid companyId);
}
