using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SurveysPortal.Modules.Surveys.QuestionAnswer.Infrastructure.DAL;

public static class ValueComparers
{
    public static readonly ValueComparer<IReadOnlyCollection<string>> ReadOnlyCollectionToJsonComparer = new(
        (l, r) => JsonSerializer.Serialize(l, Options) == JsonSerializer.Serialize(r, Options),
        v => JsonSerializer.Serialize(v, Options).GetHashCode(),
        v => JsonSerializer.Deserialize<IReadOnlyCollection<string>>(JsonSerializer.Serialize(v, Options), Options));
    
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
    };
    
}