using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimeSeriesCalculator.Application.Exceptions;
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
    public async Task<ActionResult<ApiResponse<List<PatientDto>>>> Get(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _mediator.Send(new GetAllPatientsQuery(), cancellationToken);
            return ApiResponse<List<PatientDto>>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<ActionResult<ApiResponse<PatientDto>>> Get(int id)
    {
        try
        {
            var result = await _mediator.Send(new GetPatientByIdQuery(id));
            return ApiResponse<PatientDto>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }

    [HttpPost]
    [Route("Add")]
    public async Task<ActionResult<ApiResponse<AddPatientResponse>>> Add(Guid ObjectId, string FirstName, string LastName, string Email)
    {
        try
        {
            var result = await _mediator.Send(new AddPatientCommand(ObjectId, FirstName, LastName, Email));
            return ApiResponse<AddPatientResponse>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }

    }

    [HttpPut]
    [Route("Edit")]
    public async Task<ActionResult<ApiResponse<EditPatientResponse>>> Edit(int Id, Guid ObjectId, string FirstName, string LastName, string Email)
    {
        try
        {
            var result = await _mediator.Send(new EditPatientCommand(Id, ObjectId, FirstName, LastName, Email));
            return ApiResponse<EditPatientResponse>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }

    [HttpPost]
    [Route("Delete")]
    public async Task<ActionResult<ApiResponse<DeletePatientResponse>>> Delete(int Id)
    {
        try
        {
            var result = await _mediator.Send(new DeletePatientCommand(Id));
            return ApiResponse<DeletePatientResponse>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }
}
