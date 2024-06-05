using SurveysPortal.Modules.Surveys.Standard.Core.Entities;

namespace SurveysPortal.Modules.Surveys.Standard.Application.DTO.Extensions;

public static class QueryExtensions
{
    /// <summary>
    /// Mapping StandardQuestion to QuestionDto
    /// </summary>
    /// <param name="question">like extension StandardQuestion</param>
    /// <returns>new QuestionDto or null</returns>
    public static QuestionDto? ToStandardQuestionDto(this StandardQuestion? question)
    {
        if (question != null)
        {
            return new QuestionDto
            {
                QuestionId = question.Id,
                Question = question.Text,
                Required = question.Required
            };
        }

        return null;
    }

    /// <summary>
    /// Mapping StandardQuestion list to QuestionDto list
    /// </summary>
    /// <param name="questions">like extension IEnumerable StandardQuestions</param>
    /// <returns>new QuestionDto list</returns>
    public static IEnumerable<QuestionDto> ToStandardQuestionsListDto(this IEnumerable<StandardQuestion> questions)
    {
        return questions
            .Select(x => new QuestionDto
            {
                QuestionId = x.Id,
                Question = x.Text,
                Required = x.Required
            })
            .ToList();
    }
    
    /// <summary>
    /// Mapping StandardSurvey list to SurveyDto list
    /// </summary>
    /// <param name="surveys">like extension IEnumerable StandardSurveys</param>
    /// <returns>new SurveyDto list</returns>
    public static IEnumerable<SurveyDto> ToStandardSurveysListDto(this IEnumerable<StandardSurvey> surveys)
    {
        return surveys
            .Select(x => new SurveyDto
            {
                SurveyId = x.Id,
                Survey = x.Name,
                Description = x.Description,
                Introduction = x.Introduction
            })
            .ToList();
    }
    
    /// <summary>
    /// Mapping StandardSurvey to SurveyDto
    /// </summary>
    /// <param name="survey">like extension StandardSurvey</param>
    /// <returns>new SurveyDto or null</returns>
    public static SurveyDto? ToStandardSurveyDto(this StandardSurvey? survey)
    {
        if (survey != null)
        {
            return new SurveyDto
            {
                SurveyId = survey.Id,
                Survey = survey.Name,
                Description = survey.Description,
                Introduction = survey.Introduction
            };
        }

        return null;
    }
}