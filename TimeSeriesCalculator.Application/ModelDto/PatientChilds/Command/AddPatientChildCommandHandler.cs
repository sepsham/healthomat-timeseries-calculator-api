using TimeSeriesCalculator.Application.ModelDto.PatientChilds.Dtos;
using TimeSeriesCalculator.DataAccess.Models;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.PatientChilds.Command;

public class AddPatientChildCommandHandler : IRequestHandler<AddPatientChildCommand, AddPatientChildResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddPatientChildCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AddPatientChildResponse> Handle(AddPatientChildCommand request, CancellationToken cancellationToken)
    {

        var model = new PatientChild()
        {
            Name = request.Name,
            Gender = request.Gender,
            BirthDay = request.BirthDay,
            PatientId = request.PatientId,
        };

        await _unitOfWork.PatientChildRepository.AddAsync(model);
        await _unitOfWork.CommitAsync();

        return new AddPatientChildResponse(model.Id);
    }
}
