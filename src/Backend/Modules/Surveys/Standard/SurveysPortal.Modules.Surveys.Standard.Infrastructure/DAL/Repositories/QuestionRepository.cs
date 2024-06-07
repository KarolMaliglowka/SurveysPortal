using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Surveys.Standard.Core.Entities;
using SurveysPortal.Modules.Surveys.Standard.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;

namespace SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL.Repositories;

[Injectable(ServiceLifetime.Scoped)]
public class QuestionRepository(StandardSurveysDbContext context) : IQuestionRepository
{
    public async Task<IEnumerable<StandardQuestion>> GetAllStandardQuestions() =>
        await context.StandardQuestions
            .ToListAsync();

    public Task<StandardQuestion?> GetStandardQuestionById(int id)
        => context.StandardQuestions
            .SingleOrDefaultAsync(x => x.Id == id);
    
    public async Task Create(StandardQuestion question)
    {
        await context.StandardQuestions.AddAsync(question);
        await context.SaveChangesAsync();
    }

    public async Task Update(StandardQuestion question)
    {
        context.StandardQuestions.Update(question);
        await context.SaveChangesAsync();
    }

    public async Task Delete(StandardQuestion question)
    {
        question.SetAsDeleted();
        await Update(question);
    }
}