namespace ELibrary.Application.Abstractions.EntityFramework
{
    public interface IEntityUpdater
    {
        void Update<T>(T entity) where T : class;
    }
}
