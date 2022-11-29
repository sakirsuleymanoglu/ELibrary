using ELibrary.Application.Abstractions.EntityServices;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Persistence.EntityServices.EntityFramework
{
    public class EfEntitySaver : IEntitySaver
    {
        readonly DbContext _context;
        public EfEntitySaver(DbContext context) => _context = context;
        public int Save() => _context.SaveChanges();
        public async Task<int> SaveAsync(CancellationToken cancellationToken = default) => await _context.SaveChangesAsync(cancellationToken);
    }
}
