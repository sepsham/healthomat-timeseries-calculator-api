using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Queries;

public record GetAllTimeSeriesHistoriesQuery() : IRequest<List<TimeSeriesHistoryDto>>;
