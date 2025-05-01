using HW.ApplicationDTOs.Shared;

namespace HW.Application.Services.ProfessionsLogic.Interfaces;

public interface IProfessionService
{
    Task<SimpleDTO[]> GetProffesionsSelectListAsync();
}
