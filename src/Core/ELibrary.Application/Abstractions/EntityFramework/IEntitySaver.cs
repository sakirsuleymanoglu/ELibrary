namespace ELibrary.Application.Abstractions.EntityFramework
{
    public interface IEntitySaver
    {
        int Save();
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
