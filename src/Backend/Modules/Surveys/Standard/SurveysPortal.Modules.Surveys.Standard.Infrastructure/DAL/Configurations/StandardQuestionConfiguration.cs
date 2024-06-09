using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveysPortal.Modules.Surveys.Standard.Core.Entities;
using SurveysPortal.Modules.Surveys.Standard.Core.ValueObjects;

namespace SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL.Configurations;

public class StandardQuestionConfiguration : IEntityTypeConfiguration<StandardQuestion>
{
    public void Configure(EntityTypeBuilder<StandardQuestion> builder)
    {
        builder
            .ToTable(nameof(StandardQuestion));
        builder
            .HasKey(question => question.Id);
        builder
            .Property(x => x.Question)
            .HasConversion(x => x.Value,
                x => new Question(x));
        builder
            .Property(x => x.Required);
        builder
            .Property(x => x.IsOfferedAnswers);
        builder
            .Property(q => q.OfferedAnswers).Metadata
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        builder
            .Property(q => q.OfferedAnswers)
            .HasField("_offeredAnswers")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasConversion(ValueConverters.ReadOnlyCollectionToJsonConverter)
            .Metadata.SetValueComparer(ValueComparers.ReadOnlyCollectionToJsonComparer);
        builder.Property(x => x.CreatedAt)
            .HasConversion(ValueConverters.UtcConverter);
        builder.Property(x => x.UpdatedAt)
            .HasConversion(ValueConverters.UtcConverter);
        builder.Property(x => x.IsDeleted);
        builder.Metadata
            .FindNavigation(nameof(StandardQuestion.StandardSurveyQuestions))
            ?.SetPropertyAccessMode(PropertyAccessMode.Field);
        builder
            .HasQueryFilter(x => !x.IsDeleted);
    }
}