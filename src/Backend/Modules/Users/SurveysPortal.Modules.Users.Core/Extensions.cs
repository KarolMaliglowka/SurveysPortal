using System.Diagnostics.CodeAnalysis;

namespace SurveysPortal.Modules.Users.Core;

public static class Extensions
{
    public static bool IsEmpty([NotNullWhen(false)] this string? value) => string.IsNullOrWhiteSpace(value);

    public static bool IsNotEmpty([NotNullWhen(true)] this string? value) => !string.IsNullOrWhiteSpace(value);

    public static bool IsEmail(this string value) => value.Contains('@');
}