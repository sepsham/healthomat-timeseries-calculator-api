using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimeSeriesCalculator.Application.Exceptions;
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
    public async Task<ActionResult<ApiResponse<List<PatientChildDto>>>> Get(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _mediator.Send(new GetAllPatientChildsQuery(), cancellationToken);
            return ApiResponse<List<PatientChildDto>>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<ActionResult<ApiResponse<PatientChildDto>>> Get(int id)
    {
        try
        {
            var result = await _mediator.Send(new GetPatientChildByIdQuery(id));
            return ApiResponse<PatientChildDto>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }

    [HttpPost]
    [Route("Add")]
    public async Task<ActionResult<ApiResponse<AddPatientChildResponse>>> Add(string Name, bool Gender, DateTime BirthDay, int PatientId)
    {
        try
        {
            var result = await _mediator.Send(new AddPatientChildCommand(Name, Gender, BirthDay, PatientId));
            return ApiResponse<AddPatientChildResponse>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }

    [HttpPut]
    [Route("Edit")]
    public async Task<ActionResult<ApiResponse<EditPatientChildResponse>>> Edit(int Id, string Name, bool Gender, DateTime BirthDay, int PatientId)
    {
        try
        {
            var result = await _mediator.Send(new EditPatientChildCommand(Id, Name, Gender, BirthDay, PatientId));
            return ApiResponse<EditPatientChildResponse>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }

    [HttpPost]
    [Route("Delete")]
    public async Task<ActionResult<ApiResponse<DeletePatientChildResponse>>> Delete(int Id)
    {
        try
        {
            var result = await _mediator.Send(new DeletePatientChildCommand(Id));
            return ApiResponse<DeletePatientChildResponse>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }
}
