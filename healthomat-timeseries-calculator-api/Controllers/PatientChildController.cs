using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimeSeriesCalculator.Application.ModelDto.PatientChilds.Command;
using TimeSeriesCalculator.Application.ModelDto.PatientChilds.Dtos;
using TimeSeriesCalculator.Application.ModelDto.PatientChilds.Queries;

namespace healthomat_timeseries_calculator_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientChildController : BaseController
{
    public PatientChildController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<PatientChildDto>>> Get(CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new GetAllPatientChildsQuery(), cancellationToken);
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<ActionResult<PatientChildDto>> Get(int id)
    {
        return await _mediator.Send(new GetPatientChildByIdQuery(id));
    }

    [HttpPost]
    [Route("Add")]
    public async Task<ActionResult<AddPatientChildResponse>> Add(string Name, bool Gender, DateTime BirthDay, int PatientId)
    {
        return await _mediator.Send(new AddPatientChildCommand(Name, Gender, BirthDay, PatientId));
    }

    [HttpPut]
    [Route("Edit")]
    public async Task<ActionResult<EditPatientChildResponse>> Edit(int Id, string Name, bool Gender, DateTime BirthDay, int PatientId)
    {
        return await _mediator.Send(new EditPatientChildCommand(Id, Name, Gender, BirthDay, PatientId));
    }

    [HttpPost]
    [Route("Delete")]
    public async Task<ActionResult<DeletePatientChildResponse>> Delete(int Id)
    {
        return await _mediator.Send(new DeletePatientChildCommand(Id));
    }
}
