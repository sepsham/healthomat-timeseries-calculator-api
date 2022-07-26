using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSeriesCalculator.Application.ModelDto.TimeSeries.Command;
using TimeSeriesCalculator.Application.ModelDto.TimeSeries.Dtos;
using TimeSeriesCalculator.Application.ModelDto.TimeSeries.Queries;
using TimeSeriesCalculator.DataAccess.Models.Enums;

namespace healthomat_timeseries_calculator_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSeriesController : BaseController
    {
        public TimeSeriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<TimeSeriesDto>>> Get(CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new GetAllTimeSeriesQuery(), cancellationToken);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<TimeSeriesDto>> Get(int id)
        {
            return await _mediator.Send(new GetTimeSeriesByIdQuery(id));
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<AddTimeSeriesResponse>> Add(int Month, bool Gender, TimeSeriesType Type, double P1, double P3, double P5, double P10, double P15, double P25, double P50, double P75, double P85, double P90, double P95, double P97, double P99)
        {
            return await _mediator.Send(new AddTimeSeriesCommand(Month, Gender, Type, P1, P3, P5, P10, P15, P25, P50, P75, P85, P90, P95, P97, P99));
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<ActionResult<EditTimeSeriesResponse>> Edit(int Id, int Month, bool Gender, TimeSeriesType Type, double P1, double P3, double P5, double P10, double P15, double P25, double P50, double P75, double P85, double P90, double P95, double P97, double P99)
        {
            return await _mediator.Send(new EditTimeSeriesCommand(Id, Month, Gender, Type, P1, P3, P5, P10, P15, P25, P50, P75, P85, P90, P95, P97, P99));
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult<DeleteTimeSeriesResponse>> Delete(int Id)
        {
            return await _mediator.Send(new DeleteTimeSeriesCommand(Id));
        }
    }
}
