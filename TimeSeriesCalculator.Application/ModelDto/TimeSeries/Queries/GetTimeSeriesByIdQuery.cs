using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeries.Queries;

public record GetTimeSeriesByIdQuery(int Id) : IRequest<TimeSeriesDto>;
