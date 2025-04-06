using HW.Core.Entities;

namespace HW.Core.Stores;

public interface ICompanyRepository
{
    Task<Guid> CreateAsync(Company company);
    Task<Company> GetByIdAsync(Guid companyId);
    Task UpdateAsync(Company company);
}
