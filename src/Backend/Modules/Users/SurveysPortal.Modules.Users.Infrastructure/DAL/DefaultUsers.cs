using Microsoft.EntityFrameworkCore;
using SurveysPortal.Modules.Users.Core.Entities;

namespace SurveysPortal.Modules.Users.Infrastructure.DAL;

public abstract class DefaultUsers(UsersDbContext context)
{
    public async Task SeedUsers()
    {
        var users = new List<User>
        {
            new("John", "Doe", "doej", "john.doe@surveysportal.com", "Doe John"),
            new("John", "Wick", "wickj", "john.wick@surveysportal.com", "Wick John")
        };

        foreach (var user in users)
        {
            var dbUser = await context.Users
                .FirstOrDefaultAsync(x => x.NormalizedEmail == user.NormalizedEmail);
            if (dbUser is not null) continue;
            await context.Users.AddAsync(user);
        }

        if (context.ChangeTracker.HasChanges())
        {
            await context.SaveChangesAsync();
        }
    }
}