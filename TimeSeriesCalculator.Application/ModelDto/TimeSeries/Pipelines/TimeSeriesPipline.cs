using TimeSeriesCalculator.Application.ModelDto.TimeSeries.Queries;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeries.Pipelines;

public class TimeSeriesPipline : IPipelineBehavior<GetAllTimeSeriesQuery, List<TimeSeriesDto>>
{
    public async Task<List<TimeSeriesDto>> Handle(GetAllTimeSeriesQuery request, CancellationToken cancellationToken, RequestHandlerDelegate<List<TimeSeriesDto>> next)
    {
        //Do some thing here 
        return await next();
    }
}
