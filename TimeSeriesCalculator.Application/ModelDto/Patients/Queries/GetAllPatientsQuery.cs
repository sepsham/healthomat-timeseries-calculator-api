using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.Patients.Queries;

public record GetAllPatientsQuery() : IRequest<List<PatientDto>>;
