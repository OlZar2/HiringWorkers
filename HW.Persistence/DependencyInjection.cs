using HW.Core.Stores;
using HW.Persistence.Context;
using HW.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HW.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserStore, UserRepository>();
        services.AddScoped<IAccountStore, AccountRepository>();

        return services;
    }
}
