using TimeSeriesCalculator.Application.ModelDto.Patients.Dtos;
using TimeSeriesCalculator.Application.ModelDto.Patients.Queries;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;
using System.Net;

namespace TimeSeriesCalculator.Application.ModelDto.Patients.Queries;

public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, PatientDto>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetPatientByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PatientDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _unitOfWork.PatientRepository.Get(request.Id);

        if (model == null)
            throw new Exception(("Not Found!"));

        return new PatientDto(model);
    }
}
