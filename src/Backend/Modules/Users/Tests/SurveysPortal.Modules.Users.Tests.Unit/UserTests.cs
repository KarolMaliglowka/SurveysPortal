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
        var user = UsersMockData.CreateUser;

        //Assert
        user
            .Should()
            .NotBeNull();

        user
            .Invoke()
            .FirstName
            .Should()
            .NotBeNull();

        user
            .Invoke()
            .LastName.Value
            .Should()
            .NotBeNull();

        user
            .Invoke()
            .UserName
            .Should()
            .NotBeNullOrWhiteSpace();

        user.Invoke()
            .Email
            .Should()
            .NotBeNullOrWhiteSpace();
        user.Invoke()
            .DisplayName
            .Should()
            .NotBeNullOrWhiteSpace();

        user.Invoke()
            .IsActive
            .Should()
            .BeTrue();

        user.Invoke()
            .CreatedAt
            .Should()
            .BeCloseTo(DateTime.UtcNow, 5.Seconds());

        user.Invoke()
            .UpdatedAt
            .Should()
            .BeCloseTo(DateTime.UtcNow, 5.Seconds());
    }

    // [Fact]
    // public void GivenEmptyEmail_WhenCreatingUser_ThenThrowsException()
    // {
    //     //Arrange
    //
    //     //Act
    //     Action act = () => UsersMockData.CreateUser.Email = null;
    //
    //     //Assert
    //     act
    //         .Should()
    //         .Throw<InvalidEmailException>()
    //         .WithMessage("*is invalid*");
    // }

    // [Fact]
    // public void GivenInvalidEmail_WhenCreatingUser_ThenThrowsException()
    // {
    //     //Arrange
    //
    //     //Act
    //     Action act = () => UsersMockData.CreateUser.Email = "simple text";
    //
    //     //Assert
    //     act
    //         .Should()
    //         .Throw<ArgumentException>()
    //         .WithMessage("*is not valid*");
    // }
    //
    // [Fact]
    // public void GivenInvalidLastName_WhenCreatingUser_ThenThrowsException()
    // {
    //     //Arrange
    //
    //     //Act
    //     Action act = () => UsersMockData.CreateUser.LastName = "";
    //
    //     //Assert
    //     act
    //         .Should()
    //         .Throw<ArgumentNullException>()
    //         .WithMessage("*cannot be empty*");
    // }
    //
    // [Fact]
    // public void GivenInvalidFirstName_WhenCreatingUser_ThenThrowsException()
    // {
    //     //Arrange
    //
    //     //Act
    //     Action act = () => UsersMockData.CreateUser.FirstName = "";
    //
    //     //Assert
    //     act
    //         .Should()
    //         .Throw<ArgumentNullException>()
    //         .WithMessage("*cannot be empty*");
    // }
    //
    // [Fact]
    // public void GivenInvalidUserName_WhenCreatingUser_ThenThrowsException()
    // {
    //     //Arrange
    //
    //     //Act
    //     Action act = () => UsersMockData.CreateUser.UserName = "";
    //
    //     //Assert
    //     act
    //         .Should()
    //         .Throw<ArgumentNullException>()
    //         .WithMessage("*cannot be empty*");
    // }

    [Fact]
    public void GivenValidFullName_WhenCreatingUser_ThenThrowsException()
    {
        //Arrange

        //Act
        var newUser = UsersMockData.CreateUser;

        //Assert
        newUser.Invoke()
            .GetFullName()
            .Should()
            .StartWith(newUser.Invoke().FirstName)
            .And
            .EndWith(newUser.Invoke().LastName);
    }

    [Fact]
    public void GivenValidData_WhenDeactivateUser_ThenSuccess()
    {
        //Arrange

        //Act
        var newUser = UsersMockData.CreateUser;
        newUser.Invoke()
            .Deactivate();

        //Assert
        Assert.True(newUser.Invoke().IsActive);

    }
}