using AutoMarketProject.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AutoMarketProject.Infrastructure;

public  static class MigrationManager
{
    public static async Task<IHost> AddMigrationAsync(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        using var database = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await database.Database.MigrateAsync();

        return host;
    }
}