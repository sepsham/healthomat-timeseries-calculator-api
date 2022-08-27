using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TimeSeriesCalculator.Application.Exceptions;
using TimeSeriesCalculator.Application.ModelDto.Authentication.Command;
using TimeSeriesCalculator.Application.ModelDto.Authentication.Dtos;
using TimeSeriesCalculator.Application.ModelDto.Authentication.Queries;

namespace healthomat_timeseries_calculator_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : BaseController
{
    public AuthenticationController(IMediator mediator) : base(mediator)
    {
    }


    [HttpPost]
    [Route("RegisterPatient")]
    public async Task<ActionResult<ApiResponse<RegisterPatientResponse>>> RegisterPatient(string Username, string Password, string ConfirmPassword, string FirstName, string LastName, string Email)
    {
        try
        {
            var result = await _mediator.Send(new RegisterPatientCommand(Username, Password, ConfirmPassword, FirstName, LastName, Email));
            return ApiResponse<RegisterPatientResponse>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }


    [HttpPost]
    [Route("ConfirmRegistertion")]
    public async Task<ActionResult<ApiResponse<ConfirmRegistertionResponse>>> ConfirmRegistertion(string Username, string ConfirmationCode)
    {
        try
        {
            var result = await _mediator.Send(new ConfirmRegistertionCommand(Username, ConfirmationCode));
            return ApiResponse<ConfirmRegistertionResponse>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }

    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult<ApiResponse<LoginRespone>>> Login(string Username, string Password)
    {
        try
        {
            var result = await _mediator.Send(new LoginCommand(Username, Password));
            return ApiResponse<LoginRespone>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }

   // [Authorize]
    [HttpGet]
    [Route("GetCurrentUser")]
    public async Task<ActionResult<ApiResponse<UserDto>>> GetCurrentUser()
    {
        try
        {
            var currentClaim = HttpContext.User;
       //     HttpContext.User.
         //       = "eyJraWQiOiJQUzZwOEptNUZRRjV3NnBqRTBlMDJITWNtUURjcERtZlQ4UnAxZGxydFNnPSIsImFsZyI6IlJTMjU2In0.eyJzdWIiOiI1NmVhN2QyMi02OGEzLTQ2YzEtOTYzYy02OTM0ODYxYTNiNmMiLCJjb2duaXRvOmdyb3VwcyI6WyJEb2N0b3IiXSwiZW1haWxfdmVyaWZpZWQiOnRydWUsImlzcyI6Imh0dHBzOlwvXC9jb2duaXRvLWlkcC51cy1lYXN0LTEuYW1hem9uYXdzLmNvbVwvdXMtZWFzdC0xXzlZYkdsU1RBNCIsImNvZ25pdG86dXNlcm5hbWUiOiJ1c2VyMSIsIm9yaWdpbl9qdGkiOiJhYmRmMTk1Yi03M2ExLTQ5M2UtYWM4OS0wOGFiYjk5NDUyMGMiLCJjb2duaXRvOnJvbGVzIjpbImFybjphd3M6aWFtOjo1MTk2ODQ5NDI1MTc6cm9sZVwvYXdzLXNlcnZpY2Utcm9sZVwvdHJ1c3RlZGFkdmlzb3IuYW1hem9uYXdzLmNvbVwvQVdTU2VydmljZVJvbGVGb3JUcnVzdGVkQWR2aXNvciJdLCJhdWQiOiIxdWVucXNsMTc3bGtvcmQ1MmtuZHEzNXRsYSIsImV2ZW50X2lkIjoiNDQ2Yzk4MWUtOGZiOS00NWY2LWIwYmQtYjM4MjRmZjBiOWZjIiwidG9rZW5fdXNlIjoiaWQiLCJhdXRoX3RpbWUiOjE2NjE1ODEyMDQsImV4cCI6MTY2MTU4NDgwNCwiaWF0IjoxNjYxNTgxMjA0LCJqdGkiOiJhZDQ1YjBlOC0wYmVhLTRhYjMtODM2NC1lNTc5M2Y5ZTM0NTIiLCJlbWFpbCI6InMuc2hhbWFlZUBnbWFpbC5jb20ifQ.SPRqhg98T4CA8odaS9d8BsFKkzqS0KmCdaXY78OCVAMG5x9yQmvK8u6VWoe-MxpLTXPCPXOojMAz5QrU6j8I7Q5Y2x35ylP-pLjOAnfFVj26L6f7RDzLMt61TvpYXcnVTcSNXAQSmLVCqsmpOWw3nLGT_GF2dFP860evh-MiYEJNZ8GQyhTYyv18EQkGSD59VoBngQ7CPpP5bhJxv9irxKpriuAU5DGQpSLLFkOFAuh9INGag22TZIPz1dOfT3cY59VwX4OdSKJwyClnnlCswOaFyEKvf8NyAVNTTxBcGaiyKVj3YzCtaonpszSfW7LGKYdKK5KxsZNKMwLAvizLUg";
            //  HttpContext.User.t
            var result = await _mediator.Send(new GetCurrentUserQuery(currentClaim));
            return ApiResponse<UserDto>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }
}
