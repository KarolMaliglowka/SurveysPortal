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
        => context.StandardQuestions.SingleOrDefaultAsync(x => x.Id == id);
}