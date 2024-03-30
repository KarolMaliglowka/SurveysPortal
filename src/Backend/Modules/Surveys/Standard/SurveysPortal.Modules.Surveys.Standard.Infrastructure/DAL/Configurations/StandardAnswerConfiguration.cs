using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveysPortal.Modules.Surveys.Standard.Core.Entities;

namespace SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL.Configurations;

public class StandardAnswerConfiguration : IEntityTypeConfiguration<StandardAnswer>
{
    public void Configure(EntityTypeBuilder<StandardAnswer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Answer);
        builder.Property(x => x.AnsweredAt).HasConversion(ValueConverters.UtcConverter);

        builder.HasOne(x => x.StandardSurveyUser)
            .WithMany(x => x.Answers).HasForeignKey(x => x.StandardSurveyUserId);
    }
}