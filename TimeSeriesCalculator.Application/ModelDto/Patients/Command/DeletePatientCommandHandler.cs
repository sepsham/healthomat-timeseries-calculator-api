using TimeSeriesCalculator.Application.ModelDto.Patients.Dtos;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.Patients.Command;

public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, DeletePatientResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeletePatientCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DeletePatientResponse> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {

        var model = await _unitOfWork.PatientRepository.Get(request.Id);

        if (model == null)
            throw new Exception("Not Found!");

        _unitOfWork.PatientRepository.Remove(model);
        await _unitOfWork.CommitAsync();

        return new DeletePatientResponse(request.Id);
    }
}
