using MediatR;
using TimeSeriesCalculator.Application.ModelDto.TimeSeries.Dtos;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using System.Net;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeries.Command;

public class EditTimeSeriesCommandHandler : IRequestHandler<EditTimeSeriesCommand, EditTimeSeriesResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditTimeSeriesCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EditTimeSeriesResponse> Handle(EditTimeSeriesCommand request, CancellationToken cancellationToken)
    {
        var timeSeries = await _unitOfWork.TimeSeriesRepository.Get(request.Id);

        if (timeSeries == null)
            throw new Exception(("Not Found!"));

        timeSeries.Gender = request.Gender;
        timeSeries.Month = request.Month;
        timeSeries.Type = request.Type;
        timeSeries.P1 = request.P1;
        timeSeries.P10 = request.P10;
        timeSeries.P15 = request.P15;
        timeSeries.P3 = request.P3;
        timeSeries.P5 = request.P5;
        timeSeries.P25 = request.P25;
        timeSeries.P50 = request.P50;
        timeSeries.P75 = request.P75;
        timeSeries.P85 = request.P85;
        timeSeries.P90 = request.P90;
        timeSeries.P95 = request.P95;
        timeSeries.P97 = request.P97;
        timeSeries.P99 = request.P99;

        await _unitOfWork.CommitAsync();

        return new EditTimeSeriesResponse(timeSeries.Id);
    }
}
