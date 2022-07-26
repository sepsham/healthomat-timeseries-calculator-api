using TimeSeriesCalculator.Application.ModelDto.Patients.Dtos;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.Patients.Queries;

public record GetPatientByIdQuery(int Id) : IRequest<PatientDto>;
