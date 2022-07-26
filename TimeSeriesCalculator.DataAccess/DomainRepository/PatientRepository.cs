using Microsoft.Extensions.Logging;
using TimeSeriesCalculator.DataAccess.Context;
using TimeSeriesCalculator.DataAccess.GenericRepository;
using TimeSeriesCalculator.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesCalculator.DataAccess.DomainRepository;
public interface IPatientRepository : IRepository<Patient>
{
}
public class PatientRepository : Repository<Patient>, IPatientRepository
{
    private readonly TimeSeriesCalculatorDbContext _context;
    public PatientRepository(TimeSeriesCalculatorDbContext context) : base(context)
    {
        _context = context;
    }
}
