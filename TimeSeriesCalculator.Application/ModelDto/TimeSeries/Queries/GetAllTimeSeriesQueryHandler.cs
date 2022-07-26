using MediatR;
using TimeSeriesCalculator.DataAccess.UnitOfWork;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeries.Queries;

public class GetAllTimeSeriesQueryHandler : IRequestHandler<GetAllTimeSeriesQuery, List<TimeSeriesDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTimeSeriesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<TimeSeriesDto>> Handle(GetAllTimeSeriesQuery request, CancellationToken cancellationToken)
    {
        var result = (await _unitOfWork.TimeSeriesRepository.GetAll())
                .Select(x => new TimeSeriesDto(x))
                .AsQueryable();

        return result.ToList();
    }
}
