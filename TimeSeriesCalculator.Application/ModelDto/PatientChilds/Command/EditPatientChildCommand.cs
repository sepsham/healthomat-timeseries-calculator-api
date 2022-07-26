using MediatR;
using TimeSeriesCalculator.Application.ModelDto.PatientChilds.Dtos;

namespace TimeSeriesCalculator.Application.ModelDto.PatientChilds.Command;

public record EditPatientChildCommand(int Id, string Name, bool Gender, DateTime BirthDay, int PatientId) : IRequest<EditPatientChildResponse>;
