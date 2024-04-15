using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using SurveysPortal.Modules.Surveys.Standard.Core.Entities;

namespace SurveysPortal.Modules.Surveys.Standard.Tests.Unit;

public class StandardQuestionTests
{
    private const bool IsOfferedAnswers = true;
    private const bool IsntOfferedAnswers = false;

    private readonly List<string> _someOfferedAnswersList = new()
    {
        "Answer no 1",
        "Answer no 2",
        "Answer no 3"
    };

    [Test]
    public void GivenExampleValues_WhenCreatingTextStandardQuestion_ThenSucceeds()
    {
        //arrange
        const string someStandardQuestionText = "Standard question no 1";
        StandardQuestion? standardQuestion = null;

        //act
        Action act = () => standardQuestion = new StandardQuestion(someStandardQuestionText, IsntOfferedAnswers);

        //assert
        act
            .Should()
            .NotThrow();
        standardQuestion
            .Should()
            .NotBeNull();
        standardQuestion?.Text
            .Should()
            .NotBeNull();
        standardQuestion?.Text.Length
            .Should()
            .BeGreaterThan(10);
        standardQuestion?.Text.Length
            .Should()
            .BeLessThan(1000);
        standardQuestion?.OfferedAnswers
            .Should()
            .BeEmpty();
        standardQuestion?.CreatedAt
            .Should()
            .BeCloseTo(DateTime.UtcNow, FluentTimeSpanExtensions.Seconds(5));
        standardQuestion?.UpdatedAt
            .Should()
            .BeCloseTo(DateTime.UtcNow, FluentTimeSpanExtensions.Seconds(5));
    }

    [Test]
    public void GivenExampleValues_WhenCreatingListStandardQuestion_ThenSucceeds()
    {
        //arrange
        const string someStandardQuestionText = "Standard question no 1";
        var standardQuestion = new StandardQuestion(someStandardQuestionText, IsOfferedAnswers);

        //act
        standardQuestion.SetOfferedAnswers(_someOfferedAnswersList);

        //assert
        standardQuestion
            .Should()
            .NotBeNull();
        standardQuestion.Text
            .Should()
            .NotBeNull();
        standardQuestion.Text.Length
            .Should()
            .BeGreaterThan(10);
        standardQuestion.Text.Length
            .Should()
            .BeLessThan(1000);
        standardQuestion.OfferedAnswers
            .Should()
            .NotBeEmpty();
        standardQuestion.OfferedAnswers.Count
            .Should()
            .Be(3);
        standardQuestion.CreatedAt
            .Should()
            .BeCloseTo(DateTime.UtcNow, FluentTimeSpanExtensions.Seconds(6));
        standardQuestion.UpdatedAt
            .Should()
            .BeCloseTo(DateTime.UtcNow, FluentTimeSpanExtensions.Seconds(6));
    }

    [Test]
    public void GivenSetRequired_WhenChangeParam_ThenChangedParam()
    {
        //arrange
        var question = new StandardQuestion("Question number 20", IsntOfferedAnswers);

        //act
        question.SetRequired();

        //assert
        question.UpdatedAt
            .Should()
            .BeCloseTo(DateTime.UtcNow, FluentTimeSpanExtensions.Seconds(6));
        question.Required
            .Should()
            .Be(true);
    }

    [Test]
    public void GivenUnSetRequired_WhenChangeParam_ThenChangedParam()
    {
        //arrange
        var standardQuestion = new StandardQuestion("Question number 20", IsntOfferedAnswers);

        //act
        standardQuestion
            .SetAsNotRequired();

        //assert
        standardQuestion.UpdatedAt
            .Should()
            .BeCloseTo(DateTime.UtcNow, FluentTimeSpanExtensions.Seconds(6));
        standardQuestion.Required
            .Should()
            .Be(false);
    }

    [Test]
    public void GivenSetDeleted_WhenChangeParam_ThenChangedParam()
    {
        //arrange
        var standardQuestion = new StandardQuestion("Question number 20", IsntOfferedAnswers);

        //act
        standardQuestion
            .SetAsDeleted();

        //assert
        standardQuestion.IsDeleted
            .Should()
            .Be(true);
        standardQuestion.UpdatedAt
            .Should()
            .BeCloseTo(DateTime.UtcNow, 6.Seconds());
    }

    [Test]
    public void GivenClearOfferedQuestions_WhenExistListStandardQuestion_ThenSucceeds()
    {
        //arrange
        const string someStandardQuestionText = "Standard question no 1";
        var standardQuestion = new StandardQuestion(someStandardQuestionText, IsOfferedAnswers);

        //act
        standardQuestion.SetOfferedAnswers(_someOfferedAnswersList);
        standardQuestion.ClearOfferedAnswers();

        //assert
        standardQuestion
            .Should()
            .NotBeNull();
        standardQuestion.OfferedAnswers.Count
            .Should()
            .Be(0);
        standardQuestion.UpdatedAt
            .Should()
            .BeCloseTo(DateTime.UtcNow, 6.Seconds());
    }


    [Test]
    public void GivensToShortQuestion_WhenSetQuestion_ThenError()
    {
        //arrange
        const string someStandardQuestionText = "short";

        //act
        Action act = () => new StandardQuestion(someStandardQuestionText, IsOfferedAnswers);

        //assert
        act
            .Should()
            .Throw<ArgumentException>("*cannot be shorter than 10 characters*");
    }

    [Test]
    [TestCase(IsntOfferedAnswers)]
    [TestCase(IsOfferedAnswers)]
    public void GivensToLongQuestion_WhenSetQuestion_ThenError(bool answer)
    {
        //arrange
        var someStandardQuestionText = new string('*', 1002);

        //act
        Action act = () => new StandardQuestion(someStandardQuestionText, answer);

        //assert
        act
            .Should()
            .Throw<ArgumentException>("*cannot be longer than 1000 characters*");
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [Parallelizable(ParallelScope.All)]
    public void GivensEmptyOrNullQuestion_WhenSetQuestion_ThenError(string value)
    {
        //arrange

        //act
        Action act = () => new StandardQuestion(value, IsOfferedAnswers);

        //assert
        act
            .Should()
            .Throw<ArgumentNullException>("*cannot be empty*");
    }
}
