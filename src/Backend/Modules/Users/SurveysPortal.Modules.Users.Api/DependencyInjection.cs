using SurveysPortal.Modules.Users.Core;
using SurveysPortal.Modules.Users.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace SurveysPortal.Modules.Users.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services)
    {
        services
            .AddUsersCoreLayer()
            .AddUsersInfrastructureLayer();
        return services;
    }
}