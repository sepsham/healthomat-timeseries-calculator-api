using TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Dtos;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Command;

public record DeleteZTimeSeriesCommand(int Id) : IRequest<DeleteZTimeSeriesResponse>;
