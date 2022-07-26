using TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Dtos;
using MediatR;
using TimeSeriesCalculator.DataAccess.Models.Enums;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Command;

public record AddTimeSeriesHistoryCommand(DateTime TryingDate, TimeSeriesType Type, double Value, int PatientChildId) : IRequest<AddTimeSeriesHistoryResponse>;
