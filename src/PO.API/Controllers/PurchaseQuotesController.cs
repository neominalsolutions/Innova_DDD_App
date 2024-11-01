using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PO.ApplicationLayer.Features.PQ;

namespace PO.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PurchaseQuotesController : ControllerBase
  {
    private readonly IMediator mediator;

    public PurchaseQuotesController(IMediator mediator)
    {
      this.mediator = mediator;
    }

    [HttpPut("/approve")]
    public async Task<IActionResult> Approve([FromBody] ApprovePurchaseQuoteRequestDto request)
    {
      await this.mediator.Send(request);

      return Ok();
    }



  }
}
