namespace ELibrary.Application.Abstractions.EntityFramework
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
