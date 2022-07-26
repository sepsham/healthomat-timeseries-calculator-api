using TimeSeriesCalculator.Application.ModelDto.Authentication.Dtos;
using TimeSeriesCalculator.Application.ModelDto.Authentication.Queries;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;
using System.Net;

namespace TimeSeriesCalculator.Application.ModelDto.Authentication.Queries;

public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, UserDto>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetCurrentUserQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var context = request.Claims;

        var cla = context.Claims.ToList();
        if (cla != null)
        {
            var username = cla.FirstOrDefault(x => x.Type == "cognito:username")?.Value;
            var objectId = cla.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var group = cla.FirstOrDefault(x => x.Type == "cognito:groups")?.Value;

            return new UserDto(username, Guid.Parse(objectId), group);
        }
        else
            return new UserDto(String.Empty, Guid.Empty, String.Empty);
    }
}
