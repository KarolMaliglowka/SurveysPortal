using SurveysPortal.Modules.Surveys.Standard.Core.ValueObjects;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Entities;

public class StandardUser
{


    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
    public string DisplayName { get; set; }
    
    
}