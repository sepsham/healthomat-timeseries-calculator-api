using MediatR;
using TimeSeriesCalculator.DataAccess.UnitOfWork;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeries.Queries;

public class GetTimeSeriesByIdQueryHandler : IRequestHandler<GetTimeSeriesByIdQuery, TimeSeriesDto>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetTimeSeriesByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TimeSeriesDto> Handle(GetTimeSeriesByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _unitOfWork.TimeSeriesRepository.Get(request.Id);

        if (model == null)
            throw new Exception(("Not Found!"));

        return new TimeSeriesDto(model);
    }
}
