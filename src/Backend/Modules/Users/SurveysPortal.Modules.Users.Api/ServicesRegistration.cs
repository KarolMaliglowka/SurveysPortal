using SurveysPortal.Modules.Users.Core;
using SurveysPortal.Modules.Users.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Users.Application;

namespace SurveysPortal.Modules.Users.Api;

public static class ServicesRegistration
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services)
    {
        services
            .AddUsersCoreLayer()
            .AddUsersInfrastructureLayer()
            .AddUsersApplicationLayer();
        
        return services;
    }
}