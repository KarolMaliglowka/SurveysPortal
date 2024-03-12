using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Users.Infrastructure.DAL;
using SurveysPortal.Shared.Infrastructure;
using SurveysPortal.Shared.Infrastructure.Database;

namespace SurveysPortal.Modules.Users.Infrastructure;

public static class DependencyInjection
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
}