using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using SurveysPortal.Shared.Abstractions.Attributes;

namespace SurveysPortal.Shared.Infrastructure;

public static class Extensions
{
    public static IImplementationTypeSelector InjectableAttributes(this IImplementationTypeSelector selector)
    {
        var lifeTimes = Enum.GetValues(typeof(ServiceLifetime)).Cast<ServiceLifetime>();
        return lifeTimes.Aggregate(selector, (current, item) => current.InjectableAttribute(item));
    }
    
    private static IImplementationTypeSelector InjectableAttribute(this IImplementationTypeSelector selector, ServiceLifetime lifeTime)
    {
        return selector.AddClasses(c => c.WithAttribute<InjectableAttribute>(i => i.Lifetime == lifeTime))
            .AsImplementedInterfaces()
            .WithLifetime(lifeTime);
    }
    
    public static TOptions GetOptions<TOptions>(this IServiceCollection services, string sectionName)
        where TOptions : class, new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            return configuration.GetOptions<TOptions>(sectionName);
        }
    }

    private static TOptions GetOptions<TOptions>(this IConfiguration configuration, string sectionName)
        where TOptions : class, new()
    {
        var options = new TOptions();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }
}