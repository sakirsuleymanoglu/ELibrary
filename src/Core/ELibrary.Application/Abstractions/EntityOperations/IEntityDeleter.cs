namespace ELibrary.Application.Abstractions.EntityOperations
{
    public interface IEntityDeleter
    {
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(params T[] entities) where T : class;
    }
}
