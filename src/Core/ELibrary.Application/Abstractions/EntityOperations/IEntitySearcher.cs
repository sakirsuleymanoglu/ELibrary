using System.Linq.Expressions;

namespace ELibrary.Application.Abstractions.EntityOperations
{
    public interface IEntitySearcher
    {
        Task<bool> GetAnyResultAsync<T>(Expression<Func<T, bool>>? expression = null, CancellationToken cancellationToken = default) where T : class;
        bool GetAnyResult<T>(Expression<Func<T, bool>>? expression = null) where T : class;
    }
}
