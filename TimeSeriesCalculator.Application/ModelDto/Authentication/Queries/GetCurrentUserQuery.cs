using TimeSeriesCalculator.Application.ModelDto.Authentication.Dtos;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.Authentication.Queries;

public record GetCurrentUserQuery(System.Security.Claims.ClaimsPrincipal Claims) : IRequest<UserDto>;
