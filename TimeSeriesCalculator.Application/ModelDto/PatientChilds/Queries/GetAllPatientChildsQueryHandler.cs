using MediatR;
using TimeSeriesCalculator.DataAccess.UnitOfWork;

namespace TimeSeriesCalculator.Application.ModelDto.PatientChilds.Queries;

public class GetAllPatientChildsQueryHandler : IRequestHandler<GetAllPatientChildsQuery, List<PatientChildDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPatientChildsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PatientChildDto>> Handle(GetAllPatientChildsQuery request, CancellationToken cancellationToken)
    {
        var result = (await _unitOfWork.PatientChildRepository.GetAll())
                .Select(x => new PatientChildDto(x))
                .AsQueryable();

        return result.ToList();
    }
}
