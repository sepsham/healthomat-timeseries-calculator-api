using TimeSeriesCalculator.Application.ModelDto.TimeSeries.Dtos;
using TimeSeriesCalculator.DataAccess.Models;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeries.Command;

public class AddTimeSeriesCommandHandler : IRequestHandler<AddTimeSeriesCommand, AddTimeSeriesResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddTimeSeriesCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AddTimeSeriesResponse> Handle(AddTimeSeriesCommand request, CancellationToken cancellationToken)
    {

        var model = new DataAccess.Models.TimeSeries()
        {
            Gender = request.Gender,
            Month = request.Month,
            Type = request.Type,
            P1 = request.P1,
            P10 = request.P10,
            P15 = request.P15,
            P3 = request.P3,
            P5 = request.P5,
            P25 = request.P25,
            P50 = request.P50,
            P75 = request.P75,
            P85 = request.P85,
            P90 = request.P90,
            P95 = request.P95,
            P97 = request.P97,
            P99 = request.P99,
        };

        await _unitOfWork.TimeSeriesRepository.AddAsync(model);
        await _unitOfWork.CommitAsync();

        return new AddTimeSeriesResponse(model.Id);
    }
}
