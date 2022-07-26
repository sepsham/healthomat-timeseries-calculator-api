using TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Queries;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Pipelines;

public class ZTimeSeriesPipline : IPipelineBehavior<GetAllZTimeSeriesQuery, List<ZTimeSeriesDto>>
{
    public async Task<List<ZTimeSeriesDto>> Handle(GetAllZTimeSeriesQuery request, CancellationToken cancellationToken, RequestHandlerDelegate<List<ZTimeSeriesDto>> next)
    {
        //Do some thing here 
        return await next();
    }
}
