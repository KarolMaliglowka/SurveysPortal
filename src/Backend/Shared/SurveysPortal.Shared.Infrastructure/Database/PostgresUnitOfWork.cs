using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SurveysPortal.Shared.Infrastructure.Database;

public abstract class PostgresUnitOfWork<T> : IUnitOfWork where T : DbContext
{
    private readonly T _dbContext;

    protected PostgresUnitOfWork(T dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ExecuteAsync(Func<Task> action)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            await action();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}