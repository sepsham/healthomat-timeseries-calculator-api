using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using TimeSeriesCalculator.Application.Exceptions;
using TimeSeriesCalculator.Application.ModelDto.Authentication.Command;
using TimeSeriesCalculator.Application.ModelDto.Authentication.Dtos;
using TimeSeriesCalculator.Application.ModelDto.Authentication.Queries;

namespace healthomat_timeseries_calculator_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost]
        [Route("RegisterPatient")]
        public async Task<ActionResult<ApiResponse<RegisterPatientResponse>>> RegisterPatient(string Username, string Password, string FirstName, string LastName, string Email)
        {
            try
            {
                var result = await _mediator.Send(new RegisterPatientCommand(Username, Password, FirstName, LastName, Email));
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

        [Authorize]
        [HttpGet]
        [Route("GetCurrentUser")]
        public async Task<ActionResult<ApiResponse<UserDto>>> GetCurrentUser()
        {
            try
            {
                var currentClaim = HttpContext.User;
                var result = await _mediator.Send(new GetCurrentUserQuery(currentClaim));
                return ApiResponse<UserDto>.Success(result);
            }
            catch (CustomException ex)
            {
                throw new CustomException(ex.Message);
            }
        }
    }
}
