using System.Linq.Expressions;

namespace ELibrary.Application.Abstractions.EntityOperations
{
    public interface IEntityGetter
    {
        Task<T?> GetAsync<T>(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IQueryable<T>>? optionsFunction = null, CancellationToken cancellationToken = default) where T : class;
    }
}
