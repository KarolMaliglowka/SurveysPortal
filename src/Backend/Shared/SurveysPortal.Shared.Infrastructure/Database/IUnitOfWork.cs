using System;
using System.Threading.Tasks;

namespace SurveysPortal.Shared.Infrastructure.Database;

public interface IUnitOfWork
{
    Task ExecuteAsync(Func<Task> action);
}