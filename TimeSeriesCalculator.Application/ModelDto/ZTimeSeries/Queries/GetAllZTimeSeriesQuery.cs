using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Queries;

public record GetAllZTimeSeriesQuery() : IRequest<List<ZTimeSeriesDto>>;
