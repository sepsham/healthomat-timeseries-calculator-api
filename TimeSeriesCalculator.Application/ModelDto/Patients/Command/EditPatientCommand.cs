using TimeSeriesCalculator.Application.ModelDto.Patients.Dtos;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.Patients.Command;

public record EditPatientCommand(int Id, Guid ObjectId, string FirstName, string LastName, string Email) : IRequest<EditPatientResponse>;

