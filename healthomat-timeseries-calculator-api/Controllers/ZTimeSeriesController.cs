using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimeSeriesCalculator.Application.Exceptions;
using TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Command;
using TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Dtos;
using TimeSeriesCalculator.Application.ModelDto.ZTimeSeries.Queries;
using TimeSeriesCalculator.DataAccess.Models.Enums;

namespace healthomat_timeseries_calculator_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ZTimeSeriesController : BaseController
{
    public ZTimeSeriesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<ApiResponse<List<ZTimeSeriesDto>>>> Get(bool Gender, TimeSeriesType Type, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _mediator.Send(new GetAllZTimeSeriesQuery(Gender, Type), cancellationToken);
            return ApiResponse<List<ZTimeSeriesDto>>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<ActionResult<ApiResponse<ZTimeSeriesDto>>> Get(int id)
    {
        try
        {
            var result = await _mediator.Send(new GetZTimeSeriesByIdQuery(id));
            return ApiResponse<ZTimeSeriesDto>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }

    [HttpPost]
    [Route("Add")]
    public async Task<ActionResult<ApiResponse<AddZTimeSeriesResponse>>> Add(int Month, bool Gender, TimeSeriesType Type, double SD3neg, double SD2neg, double SD1neg, double SD0, double SD1, double SD2, double SD3)
    {
        try
        {
            var result = await _mediator.Send(new AddZTimeSeriesCommand(Month, Gender, Type, SD3neg, SD2neg, SD1neg, SD0, SD1, SD2, SD3));
            return ApiResponse<AddZTimeSeriesResponse>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }

    [HttpPut]
    [Route("Edit")]
    public async Task<ActionResult<ApiResponse<EditZTimeSeriesResponse>>> Edit(int Id, int Month, bool Gender, TimeSeriesType Type, double SD3neg, double SD2neg, double SD1neg, double SD0, double SD1, double SD2, double SD3)
    {
        try
        {
            var result = await _mediator.Send(new EditZTimeSeriesCommand(Id, Month, Gender, Type, SD3neg, SD2neg, SD1neg, SD0, SD1, SD2, SD3));
            return ApiResponse<EditZTimeSeriesResponse>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }

    [HttpPost]
    [Route("Delete")]
    public async Task<ActionResult<ApiResponse<DeleteZTimeSeriesResponse>>> Delete(int Id)
    {
        try
        {
            var result = await _mediator.Send(new DeleteZTimeSeriesCommand(Id));
            return ApiResponse<DeleteZTimeSeriesResponse>.Success(result);
        }
        catch (CustomException ex)
        {
            throw new CustomException(ex.Message);
        }
    }
}
