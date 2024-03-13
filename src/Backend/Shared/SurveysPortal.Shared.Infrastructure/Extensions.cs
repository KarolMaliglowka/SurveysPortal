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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

    public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string sectionName)
        where TOptions : class, new()
    {
        var options = new TOptions();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

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