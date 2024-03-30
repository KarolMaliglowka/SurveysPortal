namespace SurveysPortal.Modules.Surveys.Standard.Core.Services;

public static class CompletionCalculator
{
    private const int OnePercent = 1;

    /// <summary>
    /// Calculates completion based on passed number of questions or competencies and answers.
    /// If  parameter canBeClosed is false then even when survey is fully completed it will have 99% completion.
    /// </summary>
    /// <param name="numberOfQuestions">number of questions</param>
    /// <param name="numberOfAnswers">numbers of answers</param>
    /// <param name="canBeClosed">can be closed</param>
    /// <returns>completion percent</returns>
    /// <exception cref="ArgumentException">Number of questions is less or equal 0.</exception>
    public static int Calculate(decimal numberOfQuestions, decimal numberOfAnswers, bool canBeClosed)
    {
        if (numberOfQuestions <= 0)
        {
            throw new ArgumentException("Number of questions is less or equal 0.");
        }

        if (numberOfAnswers == 0)
        {
            return 0;
        }

        var completion = numberOfAnswers / numberOfQuestions;
        var completionEven = (int) (Math.Round(completion, 2) * 100);
        if (!canBeClosed && completionEven == 100)
        {
            completionEven -= OnePercent;
        }

        return completionEven;
    }
}