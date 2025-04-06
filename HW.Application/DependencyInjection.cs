using HW.Application.Services.AuthLogic.Implementations;
using HW.Application.Services.AuthLogic.Interfaces;
using HW.Application.Services.CompanyLogic.Implementations;
using HW.Application.Services.CompanyLogic.Interfaces;
using HW.Application.Services.UserLogic.Implementations;
using HW.Application.Services.UserLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HW.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICompanyService, CompanyService>();

        return services;
    }
}
