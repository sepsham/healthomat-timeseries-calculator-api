using TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Dtos;
using TimeSeriesCalculator.DataAccess.Models;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Command;

public class AddTimeSeriesHistoryCommandHandler : IRequestHandler<AddTimeSeriesHistoryCommand, AddTimeSeriesHistoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddTimeSeriesHistoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AddTimeSeriesHistoryResponse> Handle(AddTimeSeriesHistoryCommand request, CancellationToken cancellationToken)
    {

        var model = new TimeSeriesHistory()
        {
            PatientChildId = request.PatientChildId,
            TryingDate = request.TryingDate,
            Type = request.Type,
            Value = request.Value,
        };

        await _unitOfWork.TimeSeriesHistoryRepository.AddAsync(model);
        await _unitOfWork.CommitAsync();

        return new AddTimeSeriesHistoryResponse(model.Id);
    }
}
