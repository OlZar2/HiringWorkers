using HW.API.Responses.Professions;
using HW.Application.Services.ProfessionsLogic.Interfaces;
using HW.ApplicationDTOs.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HW.API.Controllers;

[ApiController]
[Route("professions")]
public class ProfessionsController : ControllerBase
{
    private readonly IProfessionService _professionService;

    public ProfessionsController(IProfessionService professionService)
    {
        _professionService = professionService;
    }

    [HttpGet("select-list")]
    public async Task<ProfessionsListResponse> GetSelectList()
    {
        var professionsSelectList = await _professionService.GetProffesionsSelectListAsync();

        var response = new ProfessionsListResponse
        {
            ProfessionsList = professionsSelectList
        };

        return response;
    }
}