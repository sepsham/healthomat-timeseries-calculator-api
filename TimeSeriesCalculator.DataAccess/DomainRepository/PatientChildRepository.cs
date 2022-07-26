using TimeSeriesCalculator.DataAccess.Context;
using TimeSeriesCalculator.DataAccess.GenericRepository;
using TimeSeriesCalculator.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesCalculator.DataAccess.DomainRepository;
public interface IPatientChildRepository : IRepository<PatientChild>
{
}
public class PatientChildRepository : Repository<PatientChild>, IPatientChildRepository
{
    private readonly TimeSeriesCalculatorDbContext _context;
    public PatientChildRepository(TimeSeriesCalculatorDbContext context) : base(context)
    {
        _context = context;
    }
}
