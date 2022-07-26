using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Queries;

public record GetZTimeSeriesByIdQuery(int Id) : IRequest<ZTimeSeriesDto>;
