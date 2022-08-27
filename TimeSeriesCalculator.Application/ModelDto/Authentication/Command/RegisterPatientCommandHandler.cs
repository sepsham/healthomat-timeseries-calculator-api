using TimeSeriesCalculator.Application.ModelDto.Authentication.Dtos;
using TimeSeriesCalculator.DataAccess.Models;
using TimeSeriesCalculator.DataAccess.UnitOfWork;
using MediatR;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.CognitoIdentityProvider;
using TimeSeriesCalculator.Application.Exceptions;

namespace TimeSeriesCalculator.Application.ModelDto.Authentication.Command;

public class RegisterPatientCommandHandler : IRequestHandler<RegisterPatientCommand, RegisterPatientResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public RegisterPatientCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RegisterPatientResponse> Handle(RegisterPatientCommand request, CancellationToken cancellationToken)
    {
        if (request.Password != request.confirmPassword)
            throw new CustomException("password does not match");

        var cognito = new AmazonCognitoIdentityProviderClient(AmazonEntryPoint.Region());

        var signUp = new SignUpRequest
        {
            ClientId = AmazonEntryPoint.ClientId(),
            Password = request.Password,
            Username = request.Username,
        };


        signUp.UserAttributes.Add(new AttributeType
        {
            Name = "email",
            Value = request.Email
        });

        var response = await cognito.SignUpAsync(signUp);

        var res = await cognito.AdminAddUserToGroupAsync(new AdminAddUserToGroupRequest()
        {
            GroupName = "Doctor",
            Username = request.Username,
            UserPoolId = AmazonEntryPoint.UserPoolId(),
        });


        var model = new Patient()
        {
            Email = request.Email,
            FirstName = request.FirstName,
            ObjectId = Guid.Parse(response.UserSub),
            LastName = request.LastName
        };

        await _unitOfWork.PatientRepository.AddAsync(model);
        await _unitOfWork.CommitAsync();

        return new RegisterPatientResponse(model.Id, request.Username);
    }
}
