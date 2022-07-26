using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.PatientChilds.Queries;

public record GetAllPatientChildsQuery() : IRequest<List<PatientChildDto>>;
