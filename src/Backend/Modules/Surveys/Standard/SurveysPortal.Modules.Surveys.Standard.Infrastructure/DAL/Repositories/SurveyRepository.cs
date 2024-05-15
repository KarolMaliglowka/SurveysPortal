using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Surveys.Standard.Core.Entities;
using SurveysPortal.Modules.Surveys.Standard.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;

namespace SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL.Repositories;

[Injectable(ServiceLifetime.Scoped)]
public class SurveyRepository(StandardSurveysDbContext context) : ISurveyRepository
{
    public async Task<IEnumerable<StandardSurvey>> GetAllStandardSurveys() =>
        await context.StandardSurveys
            .ToListAsync();
    
    public Task<StandardSurvey?> GetStandardSurveyById(int id)
        => context.StandardSurveys.SingleOrDefaultAsync(x => x.Id == id);
    
    public async Task Create(StandardSurvey survey)
    {
        await context.StandardSurveys.AddAsync(survey);
        await context.SaveChangesAsync();
    }

    public async Task Update(StandardSurvey survey)
    {
        context.StandardSurveys.Update(survey);
        await context.SaveChangesAsync();
    }

    public async Task Delete(StandardSurvey survey)
    {
        survey.MarkAsDeleted();
        await Update(survey);
    }
}