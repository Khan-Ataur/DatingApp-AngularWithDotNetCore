using System;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {

        services.AddControllers();

        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });

        services.AddCors(); // this allow angular app to access this api project



        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserRepository,UserRepository>(); // AddScoped:: A single instance is created per request and shared across that request.
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


        return services;

    }
}
