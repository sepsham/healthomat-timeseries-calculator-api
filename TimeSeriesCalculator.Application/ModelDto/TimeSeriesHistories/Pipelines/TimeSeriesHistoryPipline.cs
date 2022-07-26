using TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Queries;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Pipelines;

public class TimeSeriesHistoryPipline : IPipelineBehavior<GetAllTimeSeriesHistoriesQuery, List<TimeSeriesHistoryDto>>
{
    public async Task<List<TimeSeriesHistoryDto>> Handle(GetAllTimeSeriesHistoriesQuery request, CancellationToken cancellationToken, RequestHandlerDelegate<List<TimeSeriesHistoryDto>> next)
    {
        //Do some thing here 
        return await next();
    }
}
