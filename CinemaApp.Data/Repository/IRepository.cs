using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Repository;

public interface IRepository<TEntity,TKey>
{
    IQueryable<TEntity> GetAllAttached();
    Task<TEntity> GetByIdAsync(TKey id);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity item);
    Task AddRangeAsync(TEntity[] items);
    Task<bool> UpdateAsync(TEntity item);
    bool Delete(TEntity entity);
    Task SaveChangesAsync();
}
