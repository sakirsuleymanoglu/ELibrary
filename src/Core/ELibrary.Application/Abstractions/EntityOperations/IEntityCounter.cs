using System.Linq.Expressions;

namespace ELibrary.Application.Abstractions.EntityOperations
{
    public interface IEntityCounter
    {
        Task<int> GetCountAsync<T>(Expression<Func<T, bool>>? expression = null, CancellationToken cancellationToken = default) where T : class;
        int GetCount<T>(Expression<Func<T, bool>>? expression = null) where T : class;
    }
}
