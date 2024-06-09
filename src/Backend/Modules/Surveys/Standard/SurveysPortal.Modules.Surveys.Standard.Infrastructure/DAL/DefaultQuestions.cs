using Microsoft.EntityFrameworkCore;
using SurveysPortal.Modules.Surveys.Standard.Core.Entities;

namespace SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL;

public class DefaultQuestions(StandardSurveysDbContext context)
{
    public async Task SeedStandardQuestions()
    {
        if (!context.StandardQuestions.Any())
        {
            var questions = new List<StandardQuestion>
            {
                new("First question", true),
                new("Second question", false)
            };

            foreach (var question in questions)
            {
                var dbQuestion = await context.StandardQuestions
                    .FirstOrDefaultAsync(x => x.Question == question.Question);
                if (dbQuestion is not null) continue;
                await context.StandardQuestions.AddAsync(question);
            }

            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}