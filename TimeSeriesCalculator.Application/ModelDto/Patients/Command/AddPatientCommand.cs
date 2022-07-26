using TimeSeriesCalculator.Application.ModelDto.Patients.Dtos;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.Patients.Command;

public record AddPatientCommand(Guid ObjectId, string FirstName, string LastName, string Email) : IRequest<AddPatientResponse>;
