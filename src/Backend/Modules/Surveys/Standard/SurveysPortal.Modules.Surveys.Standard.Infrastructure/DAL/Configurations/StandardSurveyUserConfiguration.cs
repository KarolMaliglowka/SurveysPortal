using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveysPortal.Modules.Surveys.Standard.Core.Entities;
using SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL.Configurations.Services;

namespace SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL.Configurations;

public class StandardSurveyUserConfiguration : IEntityTypeConfiguration<StandardSurveyUser>
{
    public void Configure(EntityTypeBuilder<StandardSurveyUser> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .Property(x => x.DueDate)
            .HasConversion(ValueConverters.UtcConverter);
        builder
            .Property(x => x.Completion);
        builder
            .HasOne(x => x.StandardSurvey)
            .WithMany(x => x.StandardSurveyParticipants)
            .HasForeignKey(x => x.StandardSurveyId)
            .IsRequired();
        builder
            .HasOne(x => x.User)
            .WithMany(x => x.StandardSurveyParticipants)
            .HasForeignKey(x => x.UserId);
        builder
            .HasMany(x => x.Answers)
            .WithOne(x => x.StandardSurveyUser)
            .OnDelete(DeleteBehavior.Cascade);
    }
}