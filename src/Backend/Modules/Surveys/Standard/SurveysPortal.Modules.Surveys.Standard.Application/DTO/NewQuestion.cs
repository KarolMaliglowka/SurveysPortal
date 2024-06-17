namespace SurveysPortal.Modules.Surveys.Standard.Application.DTO;

public record NewQuestion
{
    public string? Question { get; set; }
    public bool Required { get; set; }
}