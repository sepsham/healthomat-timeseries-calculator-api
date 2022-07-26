using MediatR;
using TimeSeriesCalculator.Application.ModelDto.TimeSeries.Queries;
using TimeSeriesCalculator.DataAccess.UnitOfWork;

namespace TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Queries;

public class GetAllZTimeSeriesQueryHandler : IRequestHandler<GetAllZTimeSeriesQuery, List<ZTimeSeriesDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllZTimeSeriesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ZTimeSeriesDto>> Handle(GetAllZTimeSeriesQuery request, CancellationToken cancellationToken)
    {
        var result = (await _unitOfWork.ZTimeSeriesRepository.GetAll())
                .Select(x => new ZTimeSeriesDto(x))
                .AsQueryable();

        return result.ToList();
    }
}
