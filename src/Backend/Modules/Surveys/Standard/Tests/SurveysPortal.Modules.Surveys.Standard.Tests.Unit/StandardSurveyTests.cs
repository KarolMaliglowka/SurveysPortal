using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using SurveysPortal.Modules.Surveys.Standard.Core.Entities;

namespace SurveysPortal.Modules.Surveys.Standard.Tests.Unit;

public class StandardSurveyTests
{
    [Test]
    public void GivenExampleValues_WhenCreatingStandardSurvey_ThenSucceeds()
    {
        //arrange
        const string someStandardSurveyName = "Standard survey";
        const string someStandardSurveyDescription = "Standard description";
        const string someStandardSurveyIntroduction = "Standard introduction";
        StandardSurvey? standardSurvey = null;

        //act
        Action act = () => standardSurvey = new StandardSurvey(someStandardSurveyName,
            someStandardSurveyDescription,
            someStandardSurveyIntroduction);

        //assert
        act
            .Should()
            .NotThrow();
        standardSurvey
            .Should()
            .NotBeNull();
        standardSurvey?.Name
            .Should()
            .NotBeNull();
        standardSurvey?.Name.Length
            .Should()
            .BeGreaterThan(3);
        standardSurvey?.Name.Length
            .Should()
            .BeLessThan(100);

        standardSurvey?.CreatedAt
            .Should()
            .BeCloseTo(DateTime.UtcNow, FluentTimeSpanExtensions.Seconds(5));
        standardSurvey?.UpdatedAt
            .Should()
            .BeCloseTo(DateTime.UtcNow, FluentTimeSpanExtensions.Seconds(5));
        standardSurvey?.Introduction
            .Should()
            .Be(someStandardSurveyIntroduction);
        standardSurvey?.Description
            .Should()
            .Be(someStandardSurveyDescription);
    }

    [Test]
    public void GivenMarkAsDeleted_WhenStandardSurveyExist_ThenSucceeds()
    {
        //arrange
        const string someStandardSurveyName = "Standard survey";
        const string someStandardSurveyDescription = "Standard description";
        const string someStandardSurveyIntroduction = "Standard introduction";

        //act
        var standardSurvey = new StandardSurvey(someStandardSurveyName,
            someStandardSurveyDescription,
            someStandardSurveyIntroduction);
        standardSurvey.MarkAsDeleted();

        //assert
        standardSurvey.IsDeleted.Should().BeTrue();
    }
}