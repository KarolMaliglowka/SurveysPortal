using Microsoft.EntityFrameworkCore;
using SurveysPortal.Modules.Surveys.Standard.Core.Entities;

namespace SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL;

public class StandardSurveysDbContext : DbContext
{
    public StandardSurveysDbContext(DbContextOptions<StandardSurveysDbContext> options) : base(options)
    {
    }

    public DbSet<StandardAnswer> StandardAnswers { get; set; }
    public DbSet<StandardQuestion> StandardQuestions { get; set; }
    public DbSet<StandardQuestionOrder> StandardQuestionOrders { get; set; }
    public DbSet<StandardSurvey> StandardSurveys { get; set; }
    public DbSet<StandardSurveyQuestion> StandardSurveyQuestions { get; set; }
    public DbSet<StandardSurveyUser> StandardSurveyUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("standardSurveys");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}