using TimeSeriesCalculator.Application.ModelDto.TimeSeries.Dtos;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeries.Command;

public record DeleteTimeSeriesCommand(int Id) : IRequest<DeleteTimeSeriesResponse>;
