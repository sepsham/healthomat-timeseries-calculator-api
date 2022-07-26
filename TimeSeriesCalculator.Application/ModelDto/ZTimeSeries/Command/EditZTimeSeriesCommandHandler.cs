using MediatR;
using TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Dtos;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using System.Net;

namespace TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Command;

public class EditZTimeSeriesCommandHandler : IRequestHandler<EditZTimeSeriesCommand, EditZTimeSeriesResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditZTimeSeriesCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EditZTimeSeriesResponse> Handle(EditZTimeSeriesCommand request, CancellationToken cancellationToken)
    {
        var zTimeSeries = await _unitOfWork.ZTimeSeriesRepository.Get(request.Id);

        if (zTimeSeries == null)
            throw new Exception(("Not Found!"));

        zTimeSeries.Gender = request.Gender;
        zTimeSeries.Month = request.Month;
        zTimeSeries.Type = request.Type;
        zTimeSeries.SD3neg = request.SD3neg;
        zTimeSeries.SD2neg = request.SD2neg;
        zTimeSeries.SD1neg = request.SD1neg;
        zTimeSeries.SD0 = request.SD0;
        zTimeSeries.SD1 = request.SD1;
        zTimeSeries.SD2 = request.SD2;
        zTimeSeries.SD3 = request.SD3;

        await _unitOfWork.CommitAsync();

        return new EditZTimeSeriesResponse(zTimeSeries.Id);
    }
}
