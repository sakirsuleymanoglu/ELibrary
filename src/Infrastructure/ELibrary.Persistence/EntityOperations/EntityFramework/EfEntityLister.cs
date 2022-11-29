using ELibrary.Application.Abstractions.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Persistence.EntityOperations.EntityFramework
{
    public class EfEntityLister : IEntityLister
    {
        readonly DbContext _context;
        public EfEntityLister(DbContext context) => _context = context;
        public async Task<List<T>> GetListAsync<T>(Func<IQueryable<T>, IQueryable<T>>? optionsFunction = null, CancellationToken cancellationToken = default) where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            if (optionsFunction != null)
                query = optionsFunction.Invoke(query);
            return await query.ToListAsync(cancellationToken);
        }
    }
}
