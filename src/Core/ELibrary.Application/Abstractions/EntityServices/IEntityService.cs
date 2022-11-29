namespace ELibrary.Application.Abstractions.EntityServices
{
    public interface IEntityService
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
