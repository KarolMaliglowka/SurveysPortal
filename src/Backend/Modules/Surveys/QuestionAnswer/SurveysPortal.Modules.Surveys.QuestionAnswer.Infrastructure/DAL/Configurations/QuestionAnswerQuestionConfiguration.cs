using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveysPortal.Modules.Surveys.QuestionAnswer.Core.Entities;

namespace SurveysPortal.Modules.Surveys.QuestionAnswer.Infrastructure.DAL.Configurations;

public class QuestionAnswerQuestionConfiguration : IEntityTypeConfiguration<QuestionAnswerQuestion>
{
    public void Configure(EntityTypeBuilder<QuestionAnswerQuestion> builder)
    {
        builder.ToTable(nameof(QuestionAnswerQuestion));
        builder.HasKey(question => question.Id);
            
        builder.Property(x => x.Text);
        builder.Property(x => x.Required);
        builder.Property(x => x.IsOfferedAnswers);
            
        builder.Property(q => q.OfferedAnswers).Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Property(q => q.OfferedAnswers)
            .HasField("_offeredAnswers")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasConversion(ValueConverters.ReadOnlyCollectionToJsonConverter)
            .Metadata.SetValueComparer(ValueComparers.ReadOnlyCollectionToJsonComparer);
            
        builder.Property(x => x.CreatedAt)
            .HasConversion(ValueConverters.UtcConverter);
        builder.Property(x => x.UpdatedAt)
            .HasConversion(ValueConverters.UtcConverter);
        builder.Property(x => x.IsDeleted);
            
        builder.Metadata.FindNavigation(nameof(QuestionAnswerQuestion.QuestionAnswerSurveyQuestions))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
            
        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}