namespace ELibrary.Application.Abstractions.EntityFramework
{
    public interface IEntityLister
    {
        Task<List<T>> GetListAsync<T>(Func<IQueryable<T>, IQueryable<T>>? optionsFunction = null, CancellationToken cancellationToken = default) where T : class;
    }
}
