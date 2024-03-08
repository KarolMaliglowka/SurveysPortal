using Xunit;
using FluentAssertions;
using FluentAssertions.Extensions;
using SurveysPortal.Modules.Users.Tests.Unit.Mocks;

namespace SurveysPortal.Modules.Users.Tests.Unit;

public class UserTests
{
    [Fact]
    public void GivenValidData_WhenCreatingUser_ThenSucceeds()
    {
        //Arrange

        //Act
        var user = UsersMockData
            .CreateUser();

        //Assert
        user
            .Should()
            .NotBeNull();

        user
            .FirstName
            .Should()
            .NotBeNullOrWhiteSpace();

        user
            .LastName
            .Should()
            .NotBeNullOrWhiteSpace();

        user
            .UserName
            .Should()
            .NotBeNullOrWhiteSpace();

        user
            .Email
            .Should()
            .NotBeNullOrWhiteSpace();
        user
            .DisplayName
            .Should()
            .NotBeNullOrWhiteSpace();

        user
            .IsActive
            .Should()
            .BeTrue();

        user
            .CreatedAt
            .Should()
            .BeCloseTo(DateTime.UtcNow, 5.Seconds());

        user
            .UpdatedAt
            .Should()
            .BeCloseTo(DateTime.UtcNow, 5.Seconds());
    }

    [Fact]
    public void GivenEmptyEmail_WhenCreatingUser_ThenThrowsException()
    {
        //Arrange

        //Act
        Action act = () => UsersMockData
            .CreateUser(email: "");

        //Assert
        act
            .Should()
            .Throw<ArgumentNullException>()
            .WithMessage("*cannot be empty*");
    }

    [Fact]
    public void GivenInvalidEmail_WhenCreatingUser_ThenThrowsException()
    {
        //Arrange

        //Act
        Action act = () => UsersMockData
            .CreateUser(email: "simple text");

        //Assert
        act
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("*is not valid*");
    }

    [Fact]
    public void GivenInvalidLastName_WhenCreatingUser_ThenThrowsException()
    {
        //Arrange

        //Act
        Action act = () => UsersMockData
            .CreateUser(lastName: "");

        //Assert
        act
            .Should()
            .Throw<ArgumentNullException>()
            .WithMessage("*cannot be empty*");
    }

    [Fact]
    public void GivenInvalidFirstName_WhenCreatingUser_ThenThrowsException()
    {
        //Arrange

        //Act
        Action act = () => UsersMockData
            .CreateUser(firstName: "");

        //Assert
        act
            .Should()
            .Throw<ArgumentNullException>()
            .WithMessage("*cannot be empty*");
    }

    [Fact]
    public void GivenInvalidUserName_WhenCreatingUser_ThenThrowsException()
    {
        //Arrange

        //Act
        Action act = () => UsersMockData
            .CreateUser(userName: "");

        //Assert
        act
            .Should()
            .Throw<ArgumentNullException>()
            .WithMessage("*cannot be empty*");
    }

    [Fact]
    public void GivenValidFullName_WhenCreatingUser_ThenThrowsException()
    {
        //Arrange

        //Act
        var newUser = UsersMockData
            .CreateUser();

        //Assert
        newUser
            .GetFullName()
            .Should()
            .StartWith(newUser.FirstName)
            .And
            .EndWith(newUser.LastName);
    }

    [Fact]
    public void GivenValidData_WhenDeactivateUser_ThenSuccess()
    {
        //Arrange

        //Act
        var newUser = UsersMockData
            .CreateUser();
        newUser
            .Deactivate();

        //Assert
        newUser
            .IsActive
            .Should()
            .BeFalse();
    }
}