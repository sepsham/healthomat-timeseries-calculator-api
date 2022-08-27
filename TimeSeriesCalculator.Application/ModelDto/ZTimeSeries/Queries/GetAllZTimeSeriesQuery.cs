using MediatR;
using TimeSeriesCalculator.DataAccess.Models.Enums;

namespace TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Queries;

public record GetAllZTimeSeriesQuery(bool Gender,TimeSeriesType Type) : IRequest<List<ZTimeSeriesDto>>;
