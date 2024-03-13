using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Shared.Abstractions.Queries;

namespace SurveysPortal.Shared.Infrastructure.Database;

public static class Extensions
{
    public static Task<Paged<T>> PaginateAsync<T>(this IQueryable<T> data, IPagedQuery query,
        CancellationToken cancellationToken = default)
        => data.PaginateAsync(query.Page, query.Results, cancellationToken);

    public static async Task<Paged<T>> PaginateAsync<T>(this IQueryable<T> data, int page, int results,
        CancellationToken cancellationToken = default)
    {
        if (page <= 0)
        {
            page = 1;
        }

        results = results switch
        {
            <= 0 => 10,
            > 100 => 100,
            _ => results
        };

        var totalResults = await data.CountAsync();
        var totalPages = totalResults <= results ? 1 : (int) Math.Floor((double) totalResults / results);
        var result = await data.Skip((page - 1) * results).Take(results).ToListAsync(cancellationToken);

        return new Paged<T>(result, page, results, totalPages, totalResults);
    }

    public static Task<List<T>> SkipAndTakeAsync<T>(this IQueryable<T> data, IPagedQuery query,
        CancellationToken cancellationToken = default)
        => data.SkipAndTakeAsync(query.Page, query.Results, cancellationToken);

    public static async Task<List<T>> SkipAndTakeAsync<T>(this IQueryable<T> data, int page, int results,
        CancellationToken cancellationToken = default)
    {
        if (page <= 0)
        {
            page = 1;
        }

        results = results switch
        {
            <= 0 => 10,
            > 100 => 100,
            _ => results
        };

        return await data.Skip((page - 1) * results).Take(results).ToListAsync(cancellationToken);
    }

    // public static IServiceCollection AddPostgres(this IServiceCollection services)
    // {
    //     var options = services.GetOptions<PostgresOptions>("postgres");
    //     services.AddSingleton(options);
    //         
    //     // Temporary fix for EF Core issue related to https://github.com/npgsql/efcore.pg/issues/2000
    //     AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    //
    //     return services;
    // }



    public static IServiceCollection AddPostgres<T>(this IServiceCollection services) where T : DbContext
    {
        var options = services.GetOptions<PostgresOptions>("postgres");
        services.AddDbContext<T>(x => x.UseNpgsql(options.ConnectionString));

        return services;
    }

}