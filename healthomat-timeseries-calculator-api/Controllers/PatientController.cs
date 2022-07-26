using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimeSeriesCalculator.Application.ModelDto.Patients.Command;
using TimeSeriesCalculator.Application.ModelDto.Patients.Dtos;
using TimeSeriesCalculator.Application.ModelDto.Patients.Queries;

namespace healthomat_timeseries_calculator_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : BaseController
{
    public PatientController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<PatientDto>>> Get(CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new GetAllPatientsQuery(), cancellationToken);
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<ActionResult<PatientDto>> Get(int id)
    {
        return await _mediator.Send(new GetPatientByIdQuery(id));
    }

    [HttpPost]
    [Route("Add")]
    public async Task<ActionResult<AddPatientResponse>> Add(Guid ObjectId, string FirstName, string LastName, string Email)
    {
        return await _mediator.Send(new AddPatientCommand(ObjectId, FirstName, LastName, Email));
    }

    [HttpPut]
    [Route("Edit")]
    public async Task<ActionResult<EditPatientResponse>> Edit(int Id, Guid ObjectId, string FirstName, string LastName, string Email)
    {
        return await _mediator.Send(new EditPatientCommand(Id, ObjectId, FirstName, LastName, Email));
    }

    [HttpPost]
    [Route("Delete")]
    public async Task<ActionResult<DeletePatientResponse>> Delete(int Id)
    {
        return await _mediator.Send(new DeletePatientCommand(Id));
    }
}
