using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Queries;

public record GetTimeSeriesHistoryByIdQuery(int Id) : IRequest<TimeSeriesHistoryDto>;
