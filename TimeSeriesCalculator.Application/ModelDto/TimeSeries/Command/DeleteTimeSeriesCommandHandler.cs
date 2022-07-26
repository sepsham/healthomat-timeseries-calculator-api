using TimeSeriesCalculator.Application.ModelDto.TimeSeries.Dtos;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeries.Command;

public class DeleteTimeSeriesCommandHandler : IRequestHandler<DeleteTimeSeriesCommand, DeleteTimeSeriesResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteTimeSeriesCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteTimeSeriesResponse> Handle(DeleteTimeSeriesCommand request, CancellationToken cancellationToken)
    {

        var model = await _unitOfWork.TimeSeriesRepository.Get(request.Id);

        if (model == null)
            throw new Exception("Not Found!");

        _unitOfWork.TimeSeriesRepository.Remove(model);
        await _unitOfWork.CommitAsync();

        return new DeleteTimeSeriesResponse(request.Id);
    }
}
