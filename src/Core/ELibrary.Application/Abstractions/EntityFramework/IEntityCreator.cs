namespace ELibrary.Application.Abstractions.EntityFramework
{
    public interface IEntityCreator
    {
        Task<T> CreateAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;
        T Create<T>(T entity) where T : class;
        Task<T[]> CreateRangeAsync<T>(params T[] entities) where T : class;
        Task<IEnumerable<T>> CreateRangeAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class;
        T[] CreateRange<T>(params T[] entities) where T : class;
    }
}
