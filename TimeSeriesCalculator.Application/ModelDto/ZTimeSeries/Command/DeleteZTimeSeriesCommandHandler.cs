using TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Dtos;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Command;

public class DeleteZTimeSeriesCommandHandler : IRequestHandler<DeleteZTimeSeriesCommand, DeleteZTimeSeriesResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteZTimeSeriesCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteZTimeSeriesResponse> Handle(DeleteZTimeSeriesCommand request, CancellationToken cancellationToken)
    {

        var model = await _unitOfWork.TimeSeriesRepository.Get(request.Id);

        if (model == null)
            throw new Exception("Not Found!");

        _unitOfWork.TimeSeriesRepository.Remove(model);
        await _unitOfWork.CommitAsync();

        return new DeleteZTimeSeriesResponse(request.Id);
    }
}
