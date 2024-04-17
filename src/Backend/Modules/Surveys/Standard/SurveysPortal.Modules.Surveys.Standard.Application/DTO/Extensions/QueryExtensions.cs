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
                Question = question.Text
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
                Question = x.Text
            })
            .ToList();
    }
}