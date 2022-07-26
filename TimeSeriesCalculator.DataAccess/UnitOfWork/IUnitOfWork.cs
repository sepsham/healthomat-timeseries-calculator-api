using TimeSeriesCalculator.DataAccess.Context;
using TimeSeriesCalculator.DataAccess.DomainRepository;

namespace TimeSeriesCalculator.DataAccess.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IPatientRepository PatientRepository { get; }
    IPatientChildRepository PatientChildRepository { get; }
    ITimeSeriesRepository TimeSeriesRepository { get; }
    IZTimeSeriesRepository ZTimeSeriesRepository { get; }
    ITimeSeriesHistoryRepository TimeSeriesHistoryRepository { get; }
    Task<int> CommitAsync();
}



public class UnitOfWork : IUnitOfWork
{
    private readonly TimeSeriesCalculatorDbContext _context;
    private readonly IPatientRepository _patientRepository;
    private readonly IPatientChildRepository _patientChildRepository;
    private readonly ITimeSeriesRepository _timeSeriesRepository;
    private readonly IZTimeSeriesRepository _zTimeSeriesRepository;
    private readonly ITimeSeriesHistoryRepository _timeSeriesHistoryRepository;

    public UnitOfWork(TimeSeriesCalculatorDbContext context, IPatientRepository patientRepository, IPatientChildRepository patientChildRepository, ITimeSeriesRepository timeSeriesRepository, IZTimeSeriesRepository zTimeSeriesRepository, ITimeSeriesHistoryRepository timeSeriesHistoryRepository)
    {
        _context = context;
        _patientRepository = patientRepository;
        _patientChildRepository = patientChildRepository;
        _timeSeriesRepository = timeSeriesRepository;
        _timeSeriesHistoryRepository = timeSeriesHistoryRepository;
        _zTimeSeriesRepository = zTimeSeriesRepository;
    }
    public IPatientRepository PatientRepository => _patientRepository;
    public IPatientChildRepository PatientChildRepository => _patientChildRepository;
    public ITimeSeriesRepository TimeSeriesRepository => _timeSeriesRepository;
    public IZTimeSeriesRepository ZTimeSeriesRepository => _zTimeSeriesRepository;
    public ITimeSeriesHistoryRepository TimeSeriesHistoryRepository => _timeSeriesHistoryRepository;

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
