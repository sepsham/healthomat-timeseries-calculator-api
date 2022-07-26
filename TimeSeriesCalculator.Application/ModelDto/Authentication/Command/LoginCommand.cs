using TimeSeriesCalculator.Application.ModelDto.Authentication.Dtos;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.Authentication.Command;

public record LoginCommand(string Username, string Password) : IRequest<LoginRespone>;

