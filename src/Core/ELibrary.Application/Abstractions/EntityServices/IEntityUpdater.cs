namespace ELibrary.Application.Abstractions.EntityServices
{
    public interface IEntityUpdater
    {
        void Update<T>(T entity) where T : class;
    }
}
