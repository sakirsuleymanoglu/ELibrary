using ELibrary.Application.Abstractions.EntityOperations;

namespace ELibrary.Application.Abstractions.Services.EntityFramework
{
    public interface IEfService
    {
        IEntitySaver Saver { get; }
        IEntityCreator Creator { get; }
        IEntityDeleter Deleter { get; }
        IEntityUpdater Updater { get; }
        IEntityGetter Getter { get; }
        IEntityLister Lister { get; }
        IEntityCounter Counter { get; }
    }
}
