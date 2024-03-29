using SurveysPortal.Modules.Users.Core.Entities;
using SurveysPortal.Modules.Users.Core.ValueObjects;

namespace SurveysPortal.Modules.Users.Tests.Unit.Mocks;

public static class UsersMockData
{
    private static readonly FirstName FirstName = new ("John");
    private static readonly LastName LastName = new ("Doe");
    private static readonly Username UserName = new ("DoeJ");
    private static readonly Email Email = new ("john.doe@email.com");

    public static User CreateUser() => new (FirstName,  LastName, UserName,
        Email, "John Doe");
}