namespace ELibrary.Application.Abstractions.EntityOperations
{
    public interface IEntityLister
    {
        Task<List<T>> GetListAsync<T>(Func<IQueryable<T>, IQueryable<T>>? optionsFunction = null, CancellationToken cancellationToken = default) where T : class;
    }
}
