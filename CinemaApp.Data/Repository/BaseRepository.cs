using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CinemaApp.Data.Repository;

public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class
{

    protected readonly CinemaAppDBContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;
    protected BaseRepository(CinemaAppDBContext dBContext)
    {
        this._dbContext = dBContext;
        this._dbSet = _dbContext.Set<TEntity>();

    }
    public async Task AddAsync(TEntity item)
    {
        this._dbSet.Add(item);
       await  this._dbContext.SaveChangesAsync();
       
    }

    public async Task AddRangeAsync(TEntity[] items)
    {
       await this._dbSet.AddRangeAsync(items);
        await this._dbContext.SaveChangesAsync();
    }

    public bool Delete(TEntity entity)
    {
        EntityEntry<TEntity> changeTrackingEntity =
            this._dbSet.Remove(entity);
         this._dbContext.SaveChanges();

        return changeTrackingEntity.State == EntityState.Deleted;
    }
    public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
      return this._dbSet.FirstOrDefaultAsync(predicate); // NE RAZBIRAM?!
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await this._dbSet.ToArrayAsync();
    }

    public IQueryable<TEntity> GetAllAttached()
    {
       return this._dbSet.AsQueryable();
    }

    public async Task<TEntity> GetByIdAsync(TKey id)
    {
      return await this._dbSet.FindAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await this._dbContext.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(TEntity item)
    {

        try
        {
            this._dbSet.Attach(item);
            this._dbSet.Entry(item).State = EntityState.Modified;
           await  this._dbContext.SaveChangesAsync();
            return true;

        }
        catch (Exception )
        {

            return false;
        }
    }
}
