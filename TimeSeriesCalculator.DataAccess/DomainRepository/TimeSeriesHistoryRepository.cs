using TimeSeriesCalculator.DataAccess.Context;
using TimeSeriesCalculator.DataAccess.GenericRepository;
using TimeSeriesCalculator.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesCalculator.DataAccess.DomainRepository;
public interface ITimeSeriesHistoryRepository : IRepository<TimeSeriesHistory>
{
}
public class TimeSeriesHistoryRepository : Repository<TimeSeriesHistory>, ITimeSeriesHistoryRepository
{
    private readonly TimeSeriesCalculatorDbContext _context;
    public TimeSeriesHistoryRepository(TimeSeriesCalculatorDbContext context) : base(context)
    {
        _context = context;
    }
}
