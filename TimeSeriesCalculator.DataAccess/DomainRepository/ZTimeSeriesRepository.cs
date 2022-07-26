using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSeriesCalculator.DataAccess.Context;
using TimeSeriesCalculator.DataAccess.GenericRepository;
using TimeSeriesCalculator.DataAccess.Models;

namespace TimeSeriesCalculator.DataAccess.DomainRepository;
public interface IZTimeSeriesRepository : IRepository<ZTimeSeries>
{
}
public class ZTimeSeriesRepository : Repository<ZTimeSeries>, IZTimeSeriesRepository
{
    private readonly TimeSeriesCalculatorDbContext _context;
    public ZTimeSeriesRepository(TimeSeriesCalculatorDbContext context) : base(context)
    {
        _context = context;
    }
}
