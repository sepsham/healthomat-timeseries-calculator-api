using MediatR;
using TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Dtos;
using TimeSeriesCalculator.DataAccess.Models.Enums;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Command;

public record EditTimeSeriesHistoryCommand(int Id, DateTime TryingDate, TimeSeriesType Type, double Value, int PatientChildId) : IRequest<EditTimeSeriesHistoryResponse>;
