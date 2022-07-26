using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeries.Queries;

public record GetAllTimeSeriesQuery() : IRequest<List<TimeSeriesDto>>;
