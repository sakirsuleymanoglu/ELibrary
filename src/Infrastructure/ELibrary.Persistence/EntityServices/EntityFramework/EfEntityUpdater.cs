using ELibrary.Application.Abstractions.EntityServices;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Persistence.EntityServices.EntityFramework
{
    public class EfEntityUpdater : IEntityUpdater
    {
        readonly DbContext _context;
        public EfEntityUpdater(DbContext context) => _context = context;
        public void Update<T>(T entity) where T : class => _context.Set<T>().Update(entity);
    }
}
