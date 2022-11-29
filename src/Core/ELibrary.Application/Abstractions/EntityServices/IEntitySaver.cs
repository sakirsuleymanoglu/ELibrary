namespace ELibrary.Application.Abstractions.EntityServices
{
    public interface IEntitySaver
    {
        int Save();
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
