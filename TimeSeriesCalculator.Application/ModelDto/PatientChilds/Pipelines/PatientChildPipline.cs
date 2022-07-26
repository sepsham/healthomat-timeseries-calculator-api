using TimeSeriesCalculator.Application.ModelDto.PatientChilds.Queries;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.PatientChilds.Pipelines;

public class PatientChildPipline : IPipelineBehavior<GetAllPatientChildsQuery, List<PatientChildDto>>
{
    public async Task<List<PatientChildDto>> Handle(GetAllPatientChildsQuery request, CancellationToken cancellationToken, RequestHandlerDelegate<List<PatientChildDto>> next)
    {
        //Do some thing here 
        return await next();
    }
}
