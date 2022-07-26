using MediatR;
using TimeSeriesCalculator.DataAccess.UnitOfWork;

namespace TimeSeriesCalculator.Application.ModelDto.PatientChilds.Queries;

public class GetPatientChildByIdQueryHandler : IRequestHandler<GetPatientChildByIdQuery, PatientChildDto>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetPatientChildByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PatientChildDto> Handle(GetPatientChildByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _unitOfWork.PatientChildRepository.Get(request.Id);

        if (model == null)
            throw new Exception(("Not Found!"));

        return new PatientChildDto(model);
    }
}
