using MediatR;
using TimeSeriesCalculator.DataAccess.Models.Enums;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeries.Queries;

public record GetAllTimeSeriesQuery(bool Gender, TimeSeriesType Type) : IRequest<List<TimeSeriesDto>>;
