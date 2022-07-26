using TimeSeriesCalculator.Application.ModelDto.PatientChilds.Dtos;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.PatientChilds.Command;

public record DeletePatientChildCommand(int Id) : IRequest<DeletePatientChildResponse>;
