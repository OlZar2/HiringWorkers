using HW.Core.Stores;
using HW.Persistence.Context;
using HW.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HW.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
    //    var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL")
    //?? throw new Exception("DATABASE_URL is not set");

    //    var uri = new Uri(databaseUrl);
    //    var db = uri.AbsolutePath.Trim('/');
    //    var userInfo = uri.UserInfo.Split(':');

    //    var connectionString =
    //        $"Server={uri.Host};Port={uri.Port};Database={db};" +
    //        $"Username={userInfo[0]};Password={userInfo[1]};" +
    //        "SSL Mode=Require;Trust Server Certificate=true;";

        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserStore, UserRepository>()
            .AddScoped<IAccountStore, AccountRepository>()
            .AddScoped<ICompanyStore, CompanyRepository>();

        return services;
    }
}