namespace ELibrary.Application.Abstractions.EntityServices
{
    public interface IEntityUpdater
    {
        void Update<T>(T entity) where T : class;
        void UpdateRange<T>(params T[] entities) where T : class;
    }
}
