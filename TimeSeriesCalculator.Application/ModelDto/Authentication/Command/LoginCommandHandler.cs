using TimeSeriesCalculator.Application.ModelDto.Authentication.Dtos;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace TimeSeriesCalculator.Application.ModelDto.Authentication.Command;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginRespone>
{
    private readonly IUnitOfWork _unitOfWork;
    public LoginCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<LoginRespone> Handle(LoginCommand request, CancellationToken cancellationToken)
    {

        var cognito = new AmazonCognitoIdentityProviderClient(AmazonEntryPoint.Region());

        var adminInitiateAuth = new AdminInitiateAuthRequest
        {
            UserPoolId = AmazonEntryPoint.UserPoolId(),
            ClientId = AmazonEntryPoint.ClientId(),
            AuthFlow = AuthFlowType.ADMIN_USER_PASSWORD_AUTH
        };
        adminInitiateAuth.AuthParameters.Add("USERNAME", request.Username);
        adminInitiateAuth.AuthParameters.Add("PASSWORD", request.Password);

        var response = await cognito.AdminInitiateAuthAsync(adminInitiateAuth);
        return new LoginRespone(response.AuthenticationResult.IdToken);
    }
}
