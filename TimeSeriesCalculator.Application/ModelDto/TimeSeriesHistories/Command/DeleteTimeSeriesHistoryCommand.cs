using TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Dtos;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Command;

public record DeleteTimeSeriesHistoryCommand(int Id) : IRequest<DeleteTimeSeriesHistoryResponse>;
