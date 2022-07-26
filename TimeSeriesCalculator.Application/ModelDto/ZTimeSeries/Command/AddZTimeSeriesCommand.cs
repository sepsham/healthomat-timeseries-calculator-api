using TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Dtos;
using MediatR;
using TimeSeriesCalculator.DataAccess.Models.Enums;

namespace TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Command;

public record AddZTimeSeriesCommand(int Month, bool Gender, TimeSeriesType Type, double SD3neg, double SD2neg, double SD1neg, double SD0, double SD1, double SD2, double SD3) : IRequest<AddZTimeSeriesResponse>;
