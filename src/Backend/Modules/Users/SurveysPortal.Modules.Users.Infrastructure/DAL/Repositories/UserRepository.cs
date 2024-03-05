using Microsoft.EntityFrameworkCore;
using SurveysPortal.Modules.Users.Core.Entities;
using SurveysPortal.Modules.Users.Core.Repositories;

namespace SurveysPortal.Modules.Users.Infrastructure.DAL.Repositories;

public class UserRepository(UsersDbContext context) : IUserRepository
{
    public Task<User?> GetAsync(Guid id)
        => context.Users.SingleOrDefaultAsync(x => x.Id == id);

    public Task<User?> GetAsync(string email)
        => context.Users.SingleOrDefaultAsync(x => x.Email == email);

    public async Task AddAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }
    
    public IQueryable<User> Query() => context.Users.AsNoTracking();
    
    public async Task Update(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }
    
    public async Task<bool> Exists(Guid id) => await context.Users.AsNoTracking().AnyAsync(x => x.Id == id);

    public async Task<IEnumerable<User>> GetAllUsers() => await context.Users.ToListAsync();
}