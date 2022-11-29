using ELibrary.Application.Abstractions.EntityOperations;
using ELibrary.Application.Abstractions.Services.EntityFramework;
using ELibrary.Persistence.Contexts.EntityFramework;
using ELibrary.Persistence.EntityOperations.EntityFramework;

namespace ELibrary.Persistence.Services.EntityFramework
{
    public class EfService : IEfService
    {
        readonly ApplicationDbContext _context;
        public EfService(ApplicationDbContext context) => _context = context;
        public IEntitySaver Saver => new EfEntitySaver(_context);
        public IEntityCreator Creator => new EfEntityCreator(_context);
        public IEntityDeleter Deleter => new EfEntityDeleter(_context);
        public IEntityUpdater Updater => new EfEntityUpdater(_context);
        public IEntityGetter Getter => new EfEntityGetter(_context);
        public IEntityLister Lister => new EfEntityLister(_context);
        public IEntityCounter Counter => new EfEntityCounter(_context);
        public IEntitySearcher Searcher => new EfEntitySearcher(_context);
    }
}
