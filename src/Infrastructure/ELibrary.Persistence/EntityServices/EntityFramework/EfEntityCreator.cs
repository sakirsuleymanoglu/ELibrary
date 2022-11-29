using ELibrary.Application.Abstractions.EntityServices;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Persistence.EntityServices.EntityFramework
{
    public class EfEntityCreator : IEntityCreator
    {
        readonly DbContext _context;

        public EfEntityCreator(DbContext context) => _context = context;

        public T Create<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> CreateAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            return entity;
        }

        public T[] CreateRange<T>(params T[] entities) where T : class
        {
            _context.Set<T>().AddRange(entities);
            return entities;
        }

        public async Task<T[]> CreateRangeAsync<T>(params T[] entities) where T : class
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> CreateRangeAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class
        {
            await _context.Set<T>().AddRangeAsync(entities, cancellationToken);
            return entities;
        }
    }
}
