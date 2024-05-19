using Microsoft.EntityFrameworkCore;
using SurveysPortal.Modules.Surveys.Standard.Core.Entities;

namespace SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL;

public class DefaultSurveys(StandardSurveysDbContext context)
{
    public async Task SeedStandardSurveys()
    {
        if (!context.StandardSurveys.Any())
        {
            var surveys = new List<StandardSurvey>
            {
                new("First survey", "First description", "First introduction"),
                new("Second survey", "Second description", "Second introduction")
            };

            foreach (var survey in surveys)
            {
                var dbSurvey = await context.StandardSurveys
                    .FirstOrDefaultAsync(x => x.Name == survey.Name);
                if (dbSurvey is not null) continue;
                await context.StandardSurveys.AddAsync(survey);
            }

            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}