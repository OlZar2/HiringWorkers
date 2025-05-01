using HW.Application.Services.ProfessionsLogic.Interfaces;
using HW.ApplicationDTOs.Shared;
using HW.Core.Stores;

namespace HW.Application.Services.ProfessionsLogic.Implementations;

public class ProfessionService : IProfessionService
{
    private readonly IProfessionRepository _professionRepository;

    public ProfessionService(IProfessionRepository professionRepository)
    {
        _professionRepository = professionRepository;
    }

    public async Task<SimpleDTO[]> GetProffesionsSelectListAsync()
    {
        var professions = await _professionRepository.GetAllAsync();

        var simpleProfessions = professions.Select(p => new SimpleDTO
        {
            Id = p.Id,
            Name = p.RussianName,
        }).ToArray();

        return simpleProfessions;
    }
}
