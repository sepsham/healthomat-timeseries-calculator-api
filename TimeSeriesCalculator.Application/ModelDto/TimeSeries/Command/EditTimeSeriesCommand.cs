using MediatR;
using TimeSeriesCalculator.Application.ModelDto.TimeSeries.Dtos;
using TimeSeriesCalculator.DataAccess.Models.Enums;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeries.Command;

public record EditTimeSeriesCommand(int Id, int Month, bool Gender, TimeSeriesType Type, double P1, double P3, double P5, double P10, double P15, double P25, double P50, double P75, double P85, double P90, double P95, double P97, double P99) : IRequest<EditTimeSeriesResponse>;
