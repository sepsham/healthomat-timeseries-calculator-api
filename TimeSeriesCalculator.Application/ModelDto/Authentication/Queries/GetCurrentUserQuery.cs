using TimeSeriesCalculator.Application.ModelDto.Authentication.Dtos;
using MediatR;
using System.Security.Claims;

namespace TimeSeriesCalculator.Application.ModelDto.Authentication.Queries;

public record GetCurrentUserQuery(ClaimsPrincipal Claims) : IRequest<UserDto>;
