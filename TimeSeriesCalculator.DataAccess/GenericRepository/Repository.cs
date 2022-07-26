using TimeSeriesCalculator.DataAccess.Models.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace TimeSeriesCalculator.DataAccess.GenericRepository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }
    public async Task<TEntity> Get(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id).ConfigureAwait(false);
    }
    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync().ConfigureAwait(false);
    }
    public IQueryable<TEntity> GetQueriable()
    {
        return _context.Set<TEntity>().AsQueryable();
    }
    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }
    public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().Where(predicate).ToListAsync().ConfigureAwait(false);
    }
    public async void AddRange(IEnumerable<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
    }
    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }
    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
    }
    public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().SingleOrDefaultAsync(predicate);
    }
    public async Task AddDublicateCheckAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate)
    {
        var existig = await _context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        if (existig != null)
            await AddAsync(entity);
    }
}

public class Repository<T, I1> : Repository<T>, IIncluder<T, I1> where T : BaseEntity
{
    protected readonly DbContext _context;
    public Repository(DbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<T>> GetAllAsync(bool includeI1 = false)
    {
        var query = GetQueriable();

        if (includeI1)
            query = query.Include(nameof(I1));

        return await query.ToListAsync();
    }
    public async ValueTask<T> GetByIdAsync(int TId, bool includeI1 = false)
    {
        var query = GetQueriable();

        if (includeI1)
            query = query.Include(nameof(I1));

        return await query.FirstOrDefaultAsync(x => x.Id == TId);
    }
}

public class Repository<T, I1, I2> : Repository<T, I1>, IIncluder<T, I1, I2> where T : BaseEntity
{
    protected readonly DbContext _context;
    public Repository(DbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<T>> GetAllAsync(bool includeI1 = false, bool includeI2 = false)
    {
        var query = GetQueriable();

        if (includeI1)
            query = query.Include(nameof(I1));
        if (includeI2)
            query = query.Include(nameof(I2));

        return await query.ToListAsync();
    }
    public async ValueTask<T> GetByIdAsync(int TId, bool includeI1 = false, bool includeI2 = false)
    {
        var query = GetQueriable();

        if (includeI1)
            query = query.Include(nameof(I1));
        if (includeI2)
            query = query.Include(nameof(I2));

        return await query.FirstOrDefaultAsync(x => x.Id == TId);
    }
}

public class Repository<T, I1, I2, I3> : Repository<T, I1, I2>, IIncluder<T, I1, I2, I3> where T : BaseEntity
{
    protected readonly DbContext _context;
    public Repository(DbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<T>> GetAllAsync(bool includeI1 = false, bool includeI2 = false, bool includeI3 = false)
    {
        var query = GetQueriable();

        if (includeI1)
            query = query.Include(nameof(I1));
        if (includeI2)
            query = query.Include(nameof(I2));
        if (includeI3)
            query = query.Include(nameof(I3));

        return await query.ToListAsync();
    }
    public async ValueTask<T> GetByIdAsync(int TId, bool includeI1 = false, bool includeI2 = false, bool includeI3 = false)
    {
        var query = GetQueriable();

        if (includeI1)
            query = query.Include(nameof(I1));
        if (includeI2)
            query = query.Include(nameof(I2));
        if (includeI3)
            query = query.Include(nameof(I3));

        return await query.FirstOrDefaultAsync(x => x.Id == TId);
    }
}

public class Repository<T, I1, I2, I3, I4> : Repository<T, I1, I2, I3>, IIncluder<T, I1, I2, I3, I4> where T : BaseEntity
{
    protected readonly DbContext _context;
    public Repository(DbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<T>> GetAllAsync(bool includeI1 = false, bool includeI2 = false, bool includeI3 = false, bool includeI4 = false)
    {
        var query = GetQueriable();

        if (includeI1)
            query = query.Include(nameof(I1));
        if (includeI2)
            query = query.Include(nameof(I2));
        if (includeI3)
            query = query.Include(nameof(I3));
        if (includeI3)
            query = query.Include(nameof(I4));

        return await query.ToListAsync();
    }
    public async ValueTask<T> GetByIdAsync(int TId, bool includeI1 = false, bool includeI2 = false, bool includeI3 = false, bool includeI4 = false)
    {
        var query = GetQueriable();

        if (includeI1)
            query = query.Include(nameof(I1));
        if (includeI2)
            query = query.Include(nameof(I2));
        if (includeI3)
            query = query.Include(nameof(I3));
        if (includeI4)
            query = query.Include(nameof(I4));

        return await query.FirstOrDefaultAsync(x => x.Id == TId);
    }
}
