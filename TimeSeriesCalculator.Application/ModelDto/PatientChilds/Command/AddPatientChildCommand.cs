using TimeSeriesCalculator.Application.ModelDto.PatientChilds.Dtos;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.PatientChilds.Command;

public record AddPatientChildCommand(string Name, bool Gender, DateTime BirthDay, int PatientId) : IRequest<AddPatientChildResponse>;
