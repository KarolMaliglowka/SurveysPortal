using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveysPortal.Modules.Surveys.Standard.Core.Entities;

namespace SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL.Configurations;

public class StandardQuestionOrderConfiguration : IEntityTypeConfiguration<StandardQuestionOrder>
{
    public void Configure(EntityTypeBuilder<StandardQuestionOrder> builder)
    {
        builder
            .HasKey(order => order.Index);
    }
}