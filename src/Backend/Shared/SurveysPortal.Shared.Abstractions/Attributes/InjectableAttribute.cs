using Microsoft.Extensions.DependencyInjection;

namespace SurveysPortal.Shared.Abstractions.Attributes;

public class InjectableAttribute(ServiceLifetime lifeTime = ServiceLifetime.Transient) : Attribute
{
    public ServiceLifetime Lifetime { get; } = lifeTime;
}