// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Scrutor;
// using SurveysPortal.Shared.Abstractions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using SurveysPortal.Shared.Abstractions.Attributes;

namespace SurveysPortal.Shared.Infrastructure;

public static class Extensions
{
    
    
    // public static IServiceCollection AddInitializer<T>(this IServiceCollection services) where T : class, IInitializer
    //     => services.AddTransient<IInitializer, T>();
    
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
    
    public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        return configuration.GetOptions<T>(sectionName);
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
    {
        var options = new T();
        configuration.GetSection(sectionName);
        return options;
    }

    public static string GetModuleName(this object value)
        => value?.GetType().GetModuleName() ?? string.Empty;

    public static string GetModuleName(this Type type, string namespacePart = "Modules", int splitIndex = 2)
    {
        if (type?.Namespace is null)
        {
            return string.Empty;
        }

        return type.Namespace.Contains(namespacePart)
            ? type.Namespace.Split(".")[splitIndex].ToLowerInvariant()
            : string.Empty;
    }
    
}