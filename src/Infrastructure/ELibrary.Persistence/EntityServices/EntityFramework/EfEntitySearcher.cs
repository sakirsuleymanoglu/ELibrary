using ELibrary.Application.Abstractions.EntityServices;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ELibrary.Persistence.EntityServices.EntityFramework
{
    public class EfEntitySearcher : IEntitySearcher
    {
        readonly DbContext _context;
        public EfEntitySearcher(DbContext context) => _context = context;
        public bool GetAnyResult<T>(Expression<Func<T, bool>>? expression = null) where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            if (expression != null)
                query = query.Where(expression);
            return query.Any();
        }
        public async Task<bool> GetAnyResultAsync<T>(Expression<Func<T, bool>>? expression = null, CancellationToken cancellationToken = default) where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            if (expression != null)
                query = query.Where(expression);
            return await query.AnyAsync(cancellationToken);
        }
    }
}
