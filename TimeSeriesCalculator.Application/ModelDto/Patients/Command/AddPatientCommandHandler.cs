using TimeSeriesCalculator.Application.ModelDto.Patients.Dtos;
using TimeSeriesCalculator.DataAccess.Models;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.Patients.Command;

public class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, AddPatientResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddPatientCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AddPatientResponse> Handle(AddPatientCommand request, CancellationToken cancellationToken)
    {

        var model = new Patient()
        {
            Email = request.Email,
            FirstName = request.FirstName,
            ObjectId = request.ObjectId,
            LastName = request.LastName
        };

        await _unitOfWork.PatientRepository.AddAsync(model);
        await _unitOfWork.CommitAsync();

        return new AddPatientResponse(model.Id);
    }
}
