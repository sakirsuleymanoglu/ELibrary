using ELibrary.Application.Abstractions.EntityServices;
using ELibrary.Persistence.Contexts.EntityFramework;
using ELibrary.Persistence.EntityOperations.EntityFramework;

namespace ELibrary.Persistence.EntityServices.EntityFramework
{
    public class EfService : IEntityService
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
