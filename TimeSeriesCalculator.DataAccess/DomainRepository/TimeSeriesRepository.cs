using Microsoft.Extensions.Logging;
using TimeSeriesCalculator.DataAccess.Context;
using TimeSeriesCalculator.DataAccess.GenericRepository;
using TimeSeriesCalculator.DataAccess.Models;


namespace TimeSeriesCalculator.DataAccess.DomainRepository;
public interface ITimeSeriesRepository : IRepository<TimeSeries>
{
}
public class TimeSeriesRepository : Repository<TimeSeries>, ITimeSeriesRepository
{
    private readonly TimeSeriesCalculatorDbContext _context;
    public TimeSeriesRepository(TimeSeriesCalculatorDbContext context) : base(context)
    {
        _context = context;
    }
}
