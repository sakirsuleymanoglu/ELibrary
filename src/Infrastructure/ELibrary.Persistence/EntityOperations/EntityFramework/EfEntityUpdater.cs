using ELibrary.Application.Abstractions.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Persistence.EntityOperations.EntityFramework
{
    public class EfEntityUpdater : IEntityUpdater
    {
        readonly DbContext _context;
        public EfEntityUpdater(DbContext context) => _context = context;
        public void Update<T>(T entity) where T : class => _context.Set<T>().Update(entity);
    }
}
