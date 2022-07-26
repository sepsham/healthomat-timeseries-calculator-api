using MediatR;
using TimeSeriesCalculator.DataAccess.UnitOfWork;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Queries;

public class GetAllTimeSeriesHistoriesQueryHandler : IRequestHandler<GetAllTimeSeriesHistoriesQuery, List<TimeSeriesHistoryDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTimeSeriesHistoriesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<TimeSeriesHistoryDto>> Handle(GetAllTimeSeriesHistoriesQuery request, CancellationToken cancellationToken)
    {
        var result = (await _unitOfWork.TimeSeriesHistoryRepository.GetAll())
                .Select(x => new TimeSeriesHistoryDto(x))
                .AsQueryable();

        return result.ToList();
    }
}
