using TimeSeriesCalculator.Application.ModelDto.Authentication.Queries;
using MediatR;

namespace TimeSeriesCalculator.Application.ModelDto.Authentication.Pipelines;

public class AuthenticationPipline : IPipelineBehavior<GetCurrentUserQuery, UserDto>
{
    public async Task<UserDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken, RequestHandlerDelegate<UserDto> next)
    {
        //Do some thing here 
        return await next();
    }
}
