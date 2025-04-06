using HW.API.Errors.Models;
using HW.API.Filters.Attributes;
using HW.Application.Services.CompanyLogic.Interfaces;
using HW.ApplicationDTOs.CompanyDTOs;
using HW.ApplicationDTOs.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HW.API.Controllers;

[ApiController]
[Authorize]
[Route("company")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet("{companyId}")]
    [SwaggerResponse(200, "Ок", typeof(CompanyInfoDTO))]
    [SwaggerResponse(401, "Не авторизован")]
    [SwaggerResponse(403, "Нет прав")]
    [SwaggerResponse(404, "Не найден", typeof(SimpleErrorModel))]
    [SwaggerResponse(500, "Ошибка сервера", typeof(SimpleErrorModel))]
    public async Task<CompanyInfoDTO> GetCompanyInfo(Guid companyId) => await _companyService.GetCompanyInfoAsync(companyId);

    [HttpPatch("{companyId}")]
    [CanChangeAccount]
    [SwaggerResponse(200, "Ок", typeof(CompanyInfoDTO))]
    [SwaggerResponse(401, "Не авторизован")]
    [SwaggerResponse(403, "Нет прав")]
    [SwaggerResponse(404, "Не найден", typeof(SimpleErrorModel))]
    [SwaggerResponse(500, "Ошибка сервера", typeof(SimpleErrorModel))]
    public async Task<CompanyInfoDTO> PatchUserInfo([FromBody] CompanyPatchDTO patchCompanyInfo, Guid companyId) =>
        await _companyService.PatchCompanyInfoAsync(patchCompanyInfo, companyId);
}