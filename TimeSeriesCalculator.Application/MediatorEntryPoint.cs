using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TimeSeriesCalculator.DataAccess.DomainRepository;
using TimeSeriesCalculator.DataAccess.UnitOfWork;

namespace TimeSeriesCalculator.Application;

public static class MediatorEntryPoint
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IPatientChildRepository, PatientChildRepository>();
        services.AddScoped<ITimeSeriesRepository, TimeSeriesRepository>();
        services.AddScoped<ITimeSeriesHistoryRepository, TimeSeriesHistoryRepository>();
        services.AddScoped<IZTimeSeriesRepository, ZTimeSeriesRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}
