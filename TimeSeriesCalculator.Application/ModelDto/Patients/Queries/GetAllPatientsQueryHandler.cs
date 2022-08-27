using MediatR;
using TimeSeriesCalculator.DataAccess.UnitOfWork;

namespace TimeSeriesCalculator.Application.ModelDto.Patients.Queries;

public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, List<PatientDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPatientsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PatientDto>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
    {
        var result = (await _unitOfWork.PatientRepository.GetAll())
                .Select(x => new PatientDto(x))
                .AsQueryable();

        return result.ToList();
    }
}
