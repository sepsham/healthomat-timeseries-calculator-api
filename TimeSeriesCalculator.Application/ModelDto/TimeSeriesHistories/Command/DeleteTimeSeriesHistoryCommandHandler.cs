using TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Dtos;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Command;

public class DeleteTimeSeriesHistoryCommandHandler : IRequestHandler<DeleteTimeSeriesHistoryCommand, DeleteTimeSeriesHistoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteTimeSeriesHistoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteTimeSeriesHistoryResponse> Handle(DeleteTimeSeriesHistoryCommand request, CancellationToken cancellationToken)
    {

        var model = await _unitOfWork.TimeSeriesHistoryRepository.Get(request.Id);

        if (model == null)
            throw new Exception("Not Found!");

        _unitOfWork.TimeSeriesHistoryRepository.Remove(model);
        await _unitOfWork.CommitAsync();

        return new DeleteTimeSeriesHistoryResponse(request.Id);
    }
}
