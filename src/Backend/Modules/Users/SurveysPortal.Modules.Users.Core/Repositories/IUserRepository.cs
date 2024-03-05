using SurveysPortal.Modules.Users.Core.Entities;

namespace SurveysPortal.Modules.Users.Core.Repositories;

public interface IUserRepository
{
    Task<User?> GetAsync(Guid id);
    Task<User?> GetAsync(string email);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    IQueryable<User> Query();
    Task Update(User user);
    Task<bool> Exists(Guid id);
    Task<IEnumerable<User>> GetAllUsers();
}