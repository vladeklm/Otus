using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;

namespace PromoCodeFactory.DataAccess.Repositories;

public abstract class EfRepository<T>: IRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext Context;
    private readonly DbSet<T> _entitySet;
    public EfRepository(AppDbContext context)
    {
        Context = context;
        _entitySet = Context.Set<T>();
    }

    public virtual async Task<List<T>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
    {
        return asNoTracking ? await _entitySet.AsNoTracking().ToListAsync(cancellationToken)
                : await _entitySet.ToListAsync(cancellationToken);
    }

    public virtual async Task<T> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _entitySet.FindAsync(id);
    }

    public virtual bool Delete(Guid id)
    {
        var obj = _entitySet.Find(id);
        if (obj == null)
        {
            return false;
        }
        _entitySet.Remove(obj);
        return true;
    }

    public virtual bool Delete(T entity)
    {
        if (entity == null)
        {
            return false;
        }
        Context.Entry(entity).State = EntityState.Deleted;
        return true;
    }

    public virtual void Update(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        return (await _entitySet.AddAsync(entity)).Entity;
    }

    public virtual async Task AddRangeAsync(ICollection<T> entities)
    {
        if (!(entities == null || !entities.Any()))
        {
            await _entitySet.AddRangeAsync(entities);
        }
    }

    public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await Context.SaveChangesAsync(cancellationToken);
    }
}