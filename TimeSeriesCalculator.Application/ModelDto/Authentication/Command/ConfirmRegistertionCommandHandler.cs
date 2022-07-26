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


        return new ConfirmRegistertionResponse(response);
    }
}
