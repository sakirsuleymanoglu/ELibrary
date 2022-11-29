using ELibrary.Application.Abstractions.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Persistence.EntityOperations.EntityFramework
{
    public class EfEntityDeleter : IEntityDeleter
    {
        readonly DbContext _context;
        public EfEntityDeleter(DbContext context) => _context = context;
        public void Delete<T>(T entity) where T : class => _context.Set<T>().Remove(entity);
        public void DeleteRange<T>(params T[] entities) where T : class => _context.Set<T>().RemoveRange(entities);
    }
}
