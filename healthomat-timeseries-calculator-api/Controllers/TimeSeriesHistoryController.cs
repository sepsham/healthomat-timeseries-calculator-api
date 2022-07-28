using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimeSeriesCalculator.Application.Exceptions;
using TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Command;
using TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Dtos;
using TimeSeriesCalculator.Application.ModelDto.TimeSeriesHistories.Queries;
using TimeSeriesCalculator.DataAccess.Models.Enums;

namespace healthomat_timeseries_calculator_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSeriesHistoryController : BaseController
    {
        public TimeSeriesHistoryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ApiResponse<List<TimeSeriesHistoryDto>>>> Get(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new GetAllTimeSeriesHistoriesQuery(), cancellationToken);
                return ApiResponse<List<TimeSeriesHistoryDto>>.Success(result);
            }
            catch (CustomException ex)
            {
                throw new CustomException(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<ApiResponse<TimeSeriesHistoryDto>>> Get(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetTimeSeriesHistoryByIdQuery(id));
                return ApiResponse<TimeSeriesHistoryDto>.Success(result);
            }
            catch (CustomException ex)
            {
                throw new CustomException(ex.Message);
            }
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<ApiResponse<AddTimeSeriesHistoryResponse>>> Add(DateTime TryingDate, TimeSeriesType Type, double Value, int PatientChildId)
        {
            try
            {
                var result = await _mediator.Send(new AddTimeSeriesHistoryCommand(TryingDate, Type, Value, PatientChildId));
                return ApiResponse<AddTimeSeriesHistoryResponse>.Success(result);
            }
            catch (CustomException ex)
            {
                throw new CustomException(ex.Message);
            }
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<ActionResult<ApiResponse<EditTimeSeriesHistoryResponse>>> Edit(int Id, DateTime TryingDate, TimeSeriesType Type, double Value, int PatientChildId)
        {
            try
            {
                var result = await _mediator.Send(new EditTimeSeriesHistoryCommand(Id, TryingDate, Type, Value, PatientChildId));
                return ApiResponse<EditTimeSeriesHistoryResponse>.Success(result);
            }
            catch (CustomException ex)
            {
                throw new CustomException(ex.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult<ApiResponse<DeleteTimeSeriesHistoryResponse>>> Delete(int Id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteTimeSeriesHistoryCommand(Id));
                return ApiResponse<DeleteTimeSeriesHistoryResponse>.Success(result);
            }
            catch (CustomException ex)
            {
                throw new CustomException(ex.Message);
            }
        }
    }
}
