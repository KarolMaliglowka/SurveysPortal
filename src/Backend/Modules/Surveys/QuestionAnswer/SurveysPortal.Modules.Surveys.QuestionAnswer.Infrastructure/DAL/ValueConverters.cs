using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SurveysPortal.Modules.Surveys.QuestionAnswer.Infrastructure.DAL;

public static class ValueConverters
{
    public static readonly ValueConverter<DateTime, DateTime> UtcConverter =
        new(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

    public static readonly ValueConverter<DateTime?, DateTime?> UtcNullableConverter =
        new(v => v,
            v => v == null
                ? v
                : DateTime.SpecifyKind(v.Value, DateTimeKind.Utc));

    public static readonly ValueConverter<IReadOnlyCollection<string>, string> ReadOnlyCollectionToJsonConverter =
        new(v => JsonSerializer.Serialize(v, Options),
            v => JsonSerializer.Deserialize<List<string>>(v, Options));
    
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
    };
}