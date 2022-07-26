using TimeSeriesCalculator.Application.ModelDto.Patients.Queries;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.Patients.Pipelines;

public class PatientPipline : IPipelineBehavior<GetAllPatientsQuery, List<PatientDto>>
{
    public async Task<List<PatientDto>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken, RequestHandlerDelegate<List<PatientDto>> next)
    {
        //Do some thing here 
        return await next();
    }
}
