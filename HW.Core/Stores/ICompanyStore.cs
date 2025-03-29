using HW.Core.Entities;

namespace HW.Core.Stores;

public interface ICompanyStore
{
    Task<Guid> CreateAsync(Company company);
}
