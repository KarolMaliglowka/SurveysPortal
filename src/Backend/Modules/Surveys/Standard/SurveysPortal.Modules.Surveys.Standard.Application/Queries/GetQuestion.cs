using SurveysPortal.Modules.Surveys.Standard.Application.DTO;
using SurveysPortal.Shared.Abstractions.Queries;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Queries;

public class GetQuestion : IQuery<QuestionDto>
{
    public Guid QuestionId { get; set; }
}