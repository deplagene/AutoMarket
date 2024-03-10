using System.Text;
using AutoMarketProject.Application.Common.Authentication;
using AutoMarketProject.Application.Common.Interfaces;
using AutoMarketProject.Application.Common.Services;
using AutoMarketProject.Domain.Abstractions;
using AutoMarketProject.Domain.Users;
using AutoMarketProject.Infrastructure.Authentication;
using AutoMarketProject.Infrastructure.Authentication.Services;
using AutoMarketProject.Infrastructure.BackgroundServices;
using AutoMarketProject.Infrastructure.Persistence;
using AutoMarketProject.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AutoMarketProject.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("Database"),
                b => b.MigrationsAssembly("AutoMarketProject")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddHostedService<OrdersCancellationBackgroundService>();

        services.ConfigureJwt(configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        return services;
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = true;
                o.Password.RequireNonAlphanumeric = false;
                o.Lockout.MaxFailedAccessAttempts = 5;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
                o.SignIn.RequireConfirmedEmail = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }

    public static IServiceCollection ConfigureJwt(this IServiceCollection services,
        IConfiguration configuration)
    {
        var jwtSetting = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSetting);

        services.AddSingleton(Options.Create(jwtSetting));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();


        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSetting.Issuer,
                    ValidAudience = jwtSetting.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSetting.Secret))
                }
            );
        
        return services;
    }
}