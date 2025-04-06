using HW.Application.Services.CompanyLogic.Interfaces;
using HW.ApplicationDTOs.CompanyDTOs;
using HW.Core.Stores;

namespace HW.Application.Services.CompanyLogic.Implementations;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyStore)
    {
        _companyRepository = companyStore;
    }

    public async Task<CompanyInfoDTO> GetCompanyInfoAsync(Guid companyId)
    {
        var company = await _companyRepository.GetByIdAsync(companyId);

        var companyDTO = new CompanyInfoDTO
        {
            CompanyName = company.CompanyName,
            Description = company.Description,
            Email = company.Email.Value,
            PhoneNumber = company.PhoneNumber.Value,
        };

        return companyDTO;
    }

    public async Task<CompanyInfoDTO> PatchCompanyInfoAsync(CompanyPatchDTO patchCompanyInfo, Guid companyId)
    {
        var company = await _companyRepository.GetByIdAsync(companyId);

        if (patchCompanyInfo.Email != null)
            company.UpdateEmail(patchCompanyInfo.Email);

        if (patchCompanyInfo.PhoneNumber != null)
            company.UpdatePhoneNumber(patchCompanyInfo.PhoneNumber);

        if (patchCompanyInfo.Description != null)
            company.UpdateDescription(patchCompanyInfo.Description);

        if (patchCompanyInfo.CompanyName != null)
            company.UpdateDescription(patchCompanyInfo.CompanyName);

        await _companyRepository.UpdateAsync(company);

        var companyDTO = new CompanyInfoDTO
        {
            CompanyName = company.CompanyName,
            Description = company.Description,
            Email = company.Email.Value,
            PhoneNumber = company.PhoneNumber.Value,
        };

        return companyDTO;
    }
}