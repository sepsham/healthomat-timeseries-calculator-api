using TimeSeriesCalculator.Application.ModelDto.Authentication.Dtos;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.Authentication.Command;

public record ConfirmRegistertionCommand(string Username, string ConfirmationCode) : IRequest<ConfirmRegistertionResponse>;

