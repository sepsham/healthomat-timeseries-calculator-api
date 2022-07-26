using MediatR;
using TimeSeriesCalculator.DataAccess.UnitOfWork;

namespace TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Queries;

public class GetZTimeSeriesByIdQueryHandler : IRequestHandler<GetZTimeSeriesByIdQuery, ZTimeSeriesDto>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetZTimeSeriesByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ZTimeSeriesDto> Handle(GetZTimeSeriesByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _unitOfWork.ZTimeSeriesRepository.Get(request.Id);

        if (model == null)
            throw new Exception(("Not Found!"));

        return new ZTimeSeriesDto(model);
    }
}
