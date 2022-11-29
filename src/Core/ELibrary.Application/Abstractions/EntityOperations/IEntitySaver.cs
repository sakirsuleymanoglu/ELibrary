namespace ELibrary.Application.Abstractions.EntityOperations
{
    public interface IEntitySaver
    {
        int Save();
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
