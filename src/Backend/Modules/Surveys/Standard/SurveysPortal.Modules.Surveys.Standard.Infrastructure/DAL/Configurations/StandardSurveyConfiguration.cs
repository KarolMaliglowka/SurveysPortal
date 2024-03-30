using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveysPortal.Modules.Surveys.Standard.Core.Entities;

namespace SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL.Configurations;

public class StandardSurveyConfiguration : IEntityTypeConfiguration<StandardSurvey>
{
    public void Configure(EntityTypeBuilder<StandardSurvey> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name);
        builder.Property(x => x.Description);
        builder.Property(x => x.Introduction);

        builder.Property(x => x.CreatedAt).HasConversion(ValueConverters.UtcConverter);
        builder.Property(x => x.UpdatedAt).HasConversion(ValueConverters.UtcConverter);
        builder.Property(x => x.IsDeleted);

        builder.Metadata.FindNavigation(nameof(StandardSurvey.StandardSurveyQuestions))
            ?.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}