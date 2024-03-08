using SurveysPortal.Modules.Users.Core.Entities;

namespace SurveysPortal.Modules.Users.Tests.Unit.Mocks;

public static class UsersMockData
{
    public static User CreateUser
    (
        string firstName = Example,
        string lastName = Example,
        string userName = Example,
        string email = EmailExample,
        string displayName = Example
    ) => new(firstName, lastName, userName, email, displayName);

    private const string Example = nameof(Example);
    private const string EmailExample = "Example@mail.com";
}