using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSeriesCalculator.Application.ModelDto.Authentication.Command;
using TimeSeriesCalculator.Application.ModelDto.Authentication.Dtos;

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
        public async Task<ActionResult<RegisterPatientResponse>> RegisterPatient(string Username, string Password, string FirstName, string LastName, string Email)
        {
            return await _mediator.Send(new RegisterPatientCommand(Username, Password, FirstName, LastName, Email));
        }
    }
}
