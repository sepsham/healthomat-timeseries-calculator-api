using TimeSeriesCalculator.DataAccess.Models.Abstraction;
using System.Linq.Expressions;


namespace TimeSeriesCalculator.DataAccess.GenericRepository;

public interface IIncluder<T,I1> :IRepository<T> where T : class
{
    ValueTask<T> GetByIdAsync(int TId, bool includeI1 = false);
    Task<IEnumerable<T>> GetAllAsync(bool includeI1 = false);
}

public interface IIncluder<T, I1,I2>:IIncluder<T, I1> where T : class
{
    ValueTask<T> GetByIdAsync(int TId, bool includeI1 = false, bool includeI2 = false);
    Task<IEnumerable<T>> GetAllAsync(bool includeI1 = false, bool includeI2 = false);
}

public interface IIncluder<T, I1, I2, I3> : IIncluder<T, I1,I2> where T : class
{
    ValueTask<T> GetByIdAsync(int TId, bool includeI1 = false, bool includeI2 = false, bool includeI3 = false);
    Task<IEnumerable<T>> GetAllAsync(bool includeI1 = false, bool includeI2 = false, bool includeI3 = false);
}
public interface IIncluder<T, I1, I2, I3,I4> : IIncluder<T, I1, I2,I3> where T : class
{
    ValueTask<T> GetByIdAsync(int TId, bool includeI1 = false, bool includeI2 = false, bool includeI3 = false, bool includeI4 = false);
    Task<IEnumerable<T>> GetAllAsync(bool includeI1 = false, bool includeI2 = false, bool includeI3 = false, bool includeI4 = false);
}
public interface IRepository<TEntity> where TEntity : class 
{
    Task<TEntity> Get(int id);
    Task<IEnumerable<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    Task AddAsync(TEntity entity);
    Task AddDublicateCheckAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate);
    void AddRange(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
}
