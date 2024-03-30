using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveysPortal.Modules.Surveys.Standard.Core.Entities;

namespace SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL.Configurations;

public class StandardSurveyQuestionConfiguration : IEntityTypeConfiguration<StandardSurveyQuestion>
{
    public void Configure(EntityTypeBuilder<StandardSurveyQuestion> builder)
    {
        builder.ToTable(nameof(StandardSurveyQuestion));
        builder.HasKey(surveyQuestion => new
        {
            surveyQuestion.StandardSurveyId,
            surveyQuestion.StandardQuestionId
        });

        builder.Property(x => x.StandardQuestionOrder);

        builder.HasOne(surveyQuestion => surveyQuestion.StandardQuestion)
            .WithMany(questions => questions.StandardSurveyQuestions)
            .HasForeignKey(surveyQuestion => surveyQuestion.StandardQuestionId);
        builder.HasOne(surveyQuestion => surveyQuestion.StandardSurvey)
            .WithMany(surveys => surveys.StandardSurveyQuestions)
            .HasForeignKey(surveyQuestion => surveyQuestion.StandardSurveyId);
    }
}