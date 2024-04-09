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
            .BeGreaterThan(10);
        standardSurvey?.Name.Length
            .Should()
            .BeLessThan(1000);

        standardSurvey?.CreatedAt
            .Should()
            .BeCloseTo(DateTime.UtcNow, FluentTimeSpanExtensions.Seconds(5));
        standardSurvey?.UpdatedAt
            .Should()
            .BeCloseTo(DateTime.UtcNow, FluentTimeSpanExtensions.Seconds(5));
    }
}