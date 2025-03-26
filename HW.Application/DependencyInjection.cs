using HW.Application.Services.AuthLogic.Implementations;
using HW.Application.Services.AuthLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HW.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
