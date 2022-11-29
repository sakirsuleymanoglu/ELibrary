using ELibrary.Application.Abstractions.EntityServices;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ELibrary.Persistence.EntityServices.EntityFramework
{
    public class EfEntityGetter : IEntityGetter
    {
        readonly DbContext _context;
        public EfEntityGetter(DbContext context) => _context = context;
        public async Task<T?> GetAsync<T>(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IQueryable<T>>? optionsFunction = null, CancellationToken cancellationToken = default) where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            if (optionsFunction != null)
                query = optionsFunction.Invoke(query);
            return await query.Where(expression).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
