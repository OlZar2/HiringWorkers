using HW.Application.Services.AuthLogic.Implementations;
using HW.Application.Services.AuthLogic.Interfaces;
using HW.Application.Services.CompanyLogic.Implementations;
using HW.Application.Services.CompanyLogic.Interfaces;
using HW.Application.Services.ImageLogic.Configurations;
using HW.Application.Services.ImageLogic.Implementations;
using HW.Application.Services.ImageLogic.Interfaces;
using HW.Application.Services.OrderLogic.Implementations;
using HW.Application.Services.OrderLogic.Interfaces;
using HW.Application.Services.ProfessionsLogic.Implementations;
using HW.Application.Services.ProfessionsLogic.Interfaces;
using HW.Application.Services.UserLogic.Implementations;
using HW.Application.Services.UserLogic.Interfaces;
using HW.ApplicationDTOs.ClaimLogic.Implementations;
using HW.ApplicationDTOs.ClaimLogic.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HW.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAuthService, AuthService>()
            .AddScoped<IPasswordHasher, PasswordHasher>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<ICompanyService, CompanyService>()
            .AddScoped<IImageService, YandexCloudImageService>()
            .AddScoped<IOrderService, OrderService>()
            .AddScoped<IProfessionService, ProfessionService>()
            .AddScoped<IClaimService, ClaimService>();

        services.Configure<S3StorageConfiguration>(configuration.GetSection(nameof(S3StorageConfiguration)));

        return services;
    }
}
