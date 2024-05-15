using SurveysPortal.Modules.Surveys.Standard.Core.Entities;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Repositories;

public interface ISurveyRepository
{
    Task<IEnumerable<StandardSurvey>> GetAllStandardSurveys();
    Task<StandardSurvey?> GetStandardSurveyById(int id);
    Task Create(StandardSurvey survey);
    Task Update(StandardSurvey survey);
    Task Delete(StandardSurvey survey);
}