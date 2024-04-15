using SurveysPortal.Modules.Surveys.Standard.Core.Entities;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Repositories;

public interface IQuestionRepository
{
    Task<IEnumerable<StandardQuestion>> GetAllStandardQuestions();
}