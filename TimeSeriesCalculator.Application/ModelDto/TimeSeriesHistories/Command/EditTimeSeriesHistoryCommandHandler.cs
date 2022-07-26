using MediatR;
using TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Dtos;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using System.Net;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Command;

public class EditTimeSeriesHistoryCommandHandler : IRequestHandler<EditTimeSeriesHistoryCommand, EditTimeSeriesHistoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditTimeSeriesHistoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EditTimeSeriesHistoryResponse> Handle(EditTimeSeriesHistoryCommand request, CancellationToken cancellationToken)
    {
        var timeSeriesHistory = await _unitOfWork.TimeSeriesHistoryRepository.Get(request.Id);

        if (timeSeriesHistory == null)
            throw new Exception(("Not Found!"));

        timeSeriesHistory.Value = request.Value;
        timeSeriesHistory.PatientChildId = request.PatientChildId;
        timeSeriesHistory.Type = request.Type;
        timeSeriesHistory.TryingDate = request.TryingDate;

        await _unitOfWork.CommitAsync();

        return new EditTimeSeriesHistoryResponse(timeSeriesHistory.Id);
    }
}
