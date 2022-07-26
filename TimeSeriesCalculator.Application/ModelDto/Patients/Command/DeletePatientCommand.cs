using TimeSeriesCalculator.Application.ModelDto.Patients.Dtos;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.Patients.Command;

public record DeletePatientCommand(int Id) : IRequest<DeletePatientResponse>;

