using TimeSeriesCalculator.Application.ModelDto.PatientChilds.Dtos;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.PatientChilds.Command;

public class DeletePatientChildCommandHandler : IRequestHandler<DeletePatientChildCommand, DeletePatientChildResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeletePatientChildCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DeletePatientChildResponse> Handle(DeletePatientChildCommand request, CancellationToken cancellationToken)
    {

        var model = await _unitOfWork.PatientChildRepository.Get(request.Id);

        if (model == null)
            throw new Exception("Not Found!");

        _unitOfWork.PatientChildRepository.Remove(model);
        await _unitOfWork.CommitAsync();

        return new DeletePatientChildResponse(request.Id);
    }
}
