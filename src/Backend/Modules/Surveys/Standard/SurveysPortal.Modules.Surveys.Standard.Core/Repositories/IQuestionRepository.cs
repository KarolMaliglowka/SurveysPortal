using SurveysPortal.Modules.Surveys.Standard.Core.Entities;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Repositories;

public interface IQuestionRepository
{
    Task<IEnumerable<StandardQuestion>> GetAllStandardQuestions();
    Task<StandardQuestion?> GetStandardQuestionById(int id);
    Task Create(StandardQuestion question);
    Task Update(StandardQuestion question);
    Task Delete(StandardQuestion question);
}