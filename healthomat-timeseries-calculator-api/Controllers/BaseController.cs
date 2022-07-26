using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace healthomat_timeseries_calculator_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;
    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

}
