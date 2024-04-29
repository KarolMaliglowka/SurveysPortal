using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SurveysPortal.Modules.Users.Infrastructure.DAL;
using SurveysPortal.Shared.Infrastructure;
using SurveysPortal.Shared.Infrastructure.Database;

namespace SurveysPortal.Modules.Users.Infrastructure;

public static class ServicesRegistration
{
    public static IServiceCollection AddUsersInfrastructureLayer(this IServiceCollection services)
    {
        services.AddPostgres<UsersDbContext>();
        services.Scan(s => s
            .FromCallingAssembly()
            .AddClasses()
            .InjectableAttributes());
        
        return services;
    }
    
    public static async Task SeedUsersData(this IHost app)
    {
        var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

        using var scope = scopedFactory?.CreateScope();
        var service = scope?.ServiceProvider.GetService<DefaultUsers>();
        if (service is null)
        {
            throw new InvalidOperationException
                ("Could not seed data due to issue with resolving service DefaultUsers");
        }

        await service.SeedUsers();
    }
}