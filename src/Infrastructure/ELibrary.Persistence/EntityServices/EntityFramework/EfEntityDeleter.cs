using ELibrary.Application.Abstractions.EntityServices;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Persistence.EntityServices.EntityFramework
{
    public class EfEntityDeleter : IEntityDeleter
    {
        readonly DbContext _context;
        public EfEntityDeleter(DbContext context) => _context = context;
        public void Delete<T>(T entity) where T : class => _context.Set<T>().Remove(entity);
        public void DeleteRange<T>(params T[] entities) where T : class => _context.Set<T>().RemoveRange(entities);
    }
}
