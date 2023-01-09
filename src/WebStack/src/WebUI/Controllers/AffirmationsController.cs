using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebStack.Application.Affirmations.Queries.GetPaginatedAffirmations;
using WebStack.Application.Common.Models;

namespace WebStack.WebUI.Controllers;

[Route("api/[controller]")]
public class AffirmationsController : ControllerBase
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [HttpGet]
    public async Task<ActionResult<PaginatedList<AffirmationListItem>>> GetPaginatedAffirmations([FromQuery] GetPaginatedAffirmationsQuery query)
    {
        return await Mediator.Send(query);
    }
}
