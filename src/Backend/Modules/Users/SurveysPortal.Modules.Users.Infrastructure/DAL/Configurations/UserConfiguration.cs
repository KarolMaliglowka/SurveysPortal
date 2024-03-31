using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveysPortal.Modules.Users.Core.Entities;
using SurveysPortal.Modules.Users.Core.ValueObjects;

namespace SurveysPortal.Modules.Users.Infrastructure.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.FirstName)
            .HasConversion(x => x.Value,
                x => new FirstName(x));
        builder
            .Property(x => x.LastName)
            .HasConversion(x => x.Value,
                x => new LastName(x));
        builder
            .Property(x => x.IsActive);
        builder
            .Property(x => x.CreatedAt);
        builder
            .Property(x => x.UpdatedAt);
    }
}