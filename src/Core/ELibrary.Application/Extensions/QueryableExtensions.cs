using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ELibrary.Application.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int size) where T : class => query.Skip(page * size).Take(size);
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression) where T : class => query.Where(expression);
        public static IQueryable<T> AddNavigationProperties<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] navigationProperties) where T : class
        {
            IQueryable<T> currentQuery = query;
            foreach (var item in navigationProperties)
                currentQuery = currentQuery.Include(item);
            return currentQuery;
        }
        public static IQueryable<T> DisableTracking<T>(this IQueryable<T> query, bool withIdentityResolution = false) where T : class
        {
            IQueryable<T> currentQuery = query;
            if (withIdentityResolution)
                currentQuery = query.AsNoTrackingWithIdentityResolution();
            else
                currentQuery = query.AsNoTracking();
            return currentQuery;
        }
    }
}
