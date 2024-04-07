using System.ComponentModel.DataAnnotations;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Entities;

public class StandardQuestionOrder
{
    public StandardQuestion? Question { get; set; }
    public int Index { get; set; }
}