using HW.ApplicationDTOs.AuthDTOs;

namespace HW.Application.Services.AuthLogic.Interfaces;

public interface IAuthService
{
    Task<Guid> RegisterUserAsync(UserRegisterDTO registerDTO);
    Task<Guid> RegisterCompanyAsync(CompanyRegisterDTO companyRegisterDTO);
    Task<string> LoginAsync(LoginDTO loginDTO);
}
