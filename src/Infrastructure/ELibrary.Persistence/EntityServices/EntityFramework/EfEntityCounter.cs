using ELibrary.Application.Abstractions.EntityServices;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ELibrary.Persistence.EntityServices.EntityFramework
{
    public class EfEntityCounter : IEntityCounter
    {
        readonly DbContext _context;
        public EfEntityCounter(DbContext context) => _context = context;
        public int GetCount<T>(Expression<Func<T, bool>>? expression = null) where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            if (expression != null)
                query = query.Where(expression);
            return query.Count();
        }
        public async Task<int> GetCountAsync<T>(Expression<Func<T, bool>>? expression = null, CancellationToken cancellationToken = default) where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            if (expression != null)
                query = query.Where(expression);
            return await query.CountAsync(cancellationToken);
        }
    }
}
