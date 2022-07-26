using Microsoft.EntityFrameworkCore;
using TimeSeriesCalculator.DataAccess.Models;

namespace TimeSeriesCalculator.DataAccess.Context;

public partial class TimeSeriesCalculatorDbContext : DbContext
{

    public TimeSeriesCalculatorDbContext()
    {
    }

    public TimeSeriesCalculatorDbContext(DbContextOptions<TimeSeriesCalculatorDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
        }
    }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientChild> PatientChildren { get; set; }
    public DbSet<TimeSeries> TimeSeries { get; set; }
    public DbSet<ZTimeSeries> ZTimeSeries { get; set; }
    public DbSet<TimeSeriesHistory> TimeSeriesHistories { get; set; }
}
