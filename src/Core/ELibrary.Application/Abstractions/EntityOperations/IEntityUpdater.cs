namespace ELibrary.Application.Abstractions.EntityOperations
{
    public interface IEntityUpdater
    {
        void Update<T>(T entity) where T : class;
    }
}
