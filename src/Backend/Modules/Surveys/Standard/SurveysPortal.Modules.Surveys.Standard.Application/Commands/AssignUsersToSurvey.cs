using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Commands;

public class AssignUsersToSurvey : ICommand
{
    public int SurveyId { get; set; }
    public List<string>? AssignUser { get; set; }
}