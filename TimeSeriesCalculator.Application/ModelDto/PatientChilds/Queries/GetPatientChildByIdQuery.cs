using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.PatientChilds.Queries;

public record GetPatientChildByIdQuery(int Id) : IRequest<PatientChildDto>;
