using MediatR;
using TimeSeriesCalculator.DataAccess.UnitOfWork;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Queries;

public class GetTimeSeriesHistoryByIdQueryHandler : IRequestHandler<GetTimeSeriesHistoryByIdQuery, TimeSeriesHistoryDto>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetTimeSeriesHistoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TimeSeriesHistoryDto> Handle(GetTimeSeriesHistoryByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _unitOfWork.TimeSeriesHistoryRepository.Get(request.Id);

        if (model == null)
            throw new Exception(("Not Found!"));

        return new TimeSeriesHistoryDto(model);
    }
}
