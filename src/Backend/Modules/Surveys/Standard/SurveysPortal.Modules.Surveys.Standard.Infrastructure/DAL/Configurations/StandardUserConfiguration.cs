using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveysPortal.Modules.Surveys.Standard.Core.Entities;
using SurveysPortal.Modules.Surveys.Standard.Core.ValueObjects;

namespace SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL.Configurations;

public class StandardUserConfiguration : IEntityTypeConfiguration<StandardUser>
{
    public void Configure(EntityTypeBuilder<StandardUser> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .Property(x => x.Question)
            .HasConversion(x => x.StandardQuestion,
                x => new Question(x));
        builder
            .Property(x => x.SurveyName)
            .HasConversion(x => x.Value,
                x => new SurveyName(x));
        builder
            .Property(x => x.Email)
            .HasConversion(x => x.Value,
                x => new Email(x));
        builder
            .Property(x => x.UserName)
            .HasConversion(x => x.Value,
                x => new Username(x));
        builder
            .Property(x => x.UpdatedAt)
            .HasConversion(ValueConverters.UtcConverter);

    }
}