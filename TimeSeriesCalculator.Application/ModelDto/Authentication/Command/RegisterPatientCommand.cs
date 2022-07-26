using TimeSeriesCalculator.Application.ModelDto.Authentication.Dtos;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.Authentication.Command;

public record RegisterPatientCommand(string Username, string Password, string FirstName, string LastName, string Email) : IRequest<RegisterPatientResponse>;
