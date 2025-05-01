using HW.Core.Entities;

namespace HW.Core.Stores;

public interface IProfessionRepository
{
    Task<Profession> GetByIdAsync(Guid id);

    Task<Profession[]> GetAllAsync();
}
