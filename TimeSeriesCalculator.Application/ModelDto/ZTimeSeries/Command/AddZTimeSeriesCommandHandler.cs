using TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Dtos;
using TimeSeriesCalculator.DataAccess.Models;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Command;

public class AddZTimeSeriesCommandHandler : IRequestHandler<AddZTimeSeriesCommand, AddZTimeSeriesResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddZTimeSeriesCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AddZTimeSeriesResponse> Handle(AddZTimeSeriesCommand request, CancellationToken cancellationToken)
    {

        var model = new DataAccess.Models.ZTimeSeries()
        {
            Gender = request.Gender,
            Month = request.Month,
            Type = request.Type,
            SD3neg = request.SD3neg,
            SD2neg = request.SD2neg,
            SD1neg = request.SD1neg,
            SD0 = request.SD0,
            SD1 = request.SD1,
            SD2 = request.SD2,
            SD3 = request.SD3,
        };

        await _unitOfWork.ZTimeSeriesRepository.AddAsync(model);
        await _unitOfWork.CommitAsync();

        return new AddZTimeSeriesResponse(model.Id);
    }
}
