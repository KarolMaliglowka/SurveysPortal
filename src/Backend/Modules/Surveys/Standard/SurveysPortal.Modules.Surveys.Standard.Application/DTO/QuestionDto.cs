namespace SurveysPortal.Modules.Surveys.Standard.Application.DTO;

public record QuestionDto
{
    public int QuestionId { get; set; }
    public string? Question { get; set; }
    public bool Required { get; set; }
}