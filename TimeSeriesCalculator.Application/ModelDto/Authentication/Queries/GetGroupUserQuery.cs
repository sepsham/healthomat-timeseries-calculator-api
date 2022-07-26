using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.Authentication.Queries;

public record GetGroupUserQuery(string Username) : IRequest<GroupDto>;
