using TimeSeriesCalculator.Application.ModelDto.Authentication.Dtos;
using TimeSeriesCalculator.Application.ModelDto.Authentication.Queries;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace TimeSeriesCalculator.Application.ModelDto.Authentication.Queries;

public class GetGroupUserQueryHandler : IRequestHandler<GetGroupUserQuery, GroupDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetGroupUserQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GroupDto> Handle(GetGroupUserQuery request, CancellationToken cancellationToken)
    {
        var cognito = new AmazonCognitoIdentityProviderClient(AmazonEntryPoint.Region());

        var userGroup = await cognito.AdminListGroupsForUserAsync(new AdminListGroupsForUserRequest()
        {
            Username = request.Username,
            UserPoolId = AmazonEntryPoint.UserPoolId(),
            Limit = 10,
        });

        

        return new GroupDto(userGroup.Groups.First().GroupName);
    }
}
