namespace ELibrary.Application.Abstractions.EntityServices
{
    public interface IEntityDeleter
    {
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(params T[] entities) where T : class;
    }
}
