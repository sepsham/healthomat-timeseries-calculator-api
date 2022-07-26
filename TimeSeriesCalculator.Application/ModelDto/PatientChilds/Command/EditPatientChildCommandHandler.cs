using MediatR;
using TimeSeriesCalculator.Application.ModelDto.PatientChilds.Dtos;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using System.Net;

namespace TimeSeriesCalculator.Application.ModelDto.PatientChilds.Command;

public class EditPatientChildCommandHandler : IRequestHandler<EditPatientChildCommand, EditPatientChildResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditPatientChildCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EditPatientChildResponse> Handle(EditPatientChildCommand request, CancellationToken cancellationToken)
    {
        var patientChild = await _unitOfWork.PatientChildRepository.Get(request.Id);

        if (patientChild == null)
            throw new Exception(("Not Found!"));

        patientChild.Name = request.Name;
        patientChild.BirthDay = request.BirthDay;
        patientChild.Gender = request.Gender;
        patientChild.PatientId = request.PatientId;


        await _unitOfWork.CommitAsync();

        return new EditPatientChildResponse(patientChild.Id);
    }
}
