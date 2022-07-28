using TimeSeriesCalculator.Application.ModelDto.Authentication.Dtos;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace TimeSeriesCalculator.Application.ModelDto.Authentication.Command;

public class ConfirmRegistertionCommandHandler : IRequestHandler<ConfirmRegistertionCommand, ConfirmRegistertionResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public ConfirmRegistertionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ConfirmRegistertionResponse> Handle(ConfirmRegistertionCommand request, CancellationToken cancellationToken)
    {

        var cognito = new AmazonCognitoIdentityProviderClient(AmazonEntryPoint.Region());

        var confirmSignUp = new ConfirmSignUpRequest
        {
            ClientId = AmazonEntryPoint.ClientId(),
            Username = request.Username,
            ConfirmationCode = request.ConfirmationCode,
        };

        var response = await cognito.ConfirmSignUpAsync(confirmSignUp);

        //var adminInitiateAuth = new AdminInitiateAuthRequest
        //{
        //    UserPoolId = AmazonEntryPoint.UserPoolId(),
        //    ClientId = AmazonEntryPoint.ClientId(),
        //    AuthFlow = AuthFlowType.ADMIN_USER_PASSWORD_AUTH
        //};
        //adminInitiateAuth.AuthParameters.Add("USERNAME", request.Username);
        //adminInitiateAuth.AuthParameters.Add("PASSWORD", request.Password);

        //var user = await cognito.AdminInitiateAuthAsync(adminInitiateAuth);


        return new ConfirmRegistertionResponse(response);
    }
}
