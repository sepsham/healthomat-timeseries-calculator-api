using TimeSeriesCalculator.Application.ModelDto.Patients.Dtos;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;
using System.Net;

namespace TimeSeriesCalculator.Application.ModelDto.Patients.Command;

public class EditPatientCommandHandler : IRequestHandler<EditPatientCommand, EditPatientResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditPatientCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EditPatientResponse> Handle(EditPatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _unitOfWork.PatientRepository.Get(request.Id);

        if (patient == null)
            throw new Exception(("Not Found!"));

        patient.FirstName = request.FirstName;
        patient.LastName = request.LastName;
        patient.Email = request.Email;

        await _unitOfWork.CommitAsync();

        return new EditPatientResponse(patient.Id);
    }
}
