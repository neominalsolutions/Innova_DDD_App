using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PO.DomainLayer.Aggregates.PQ;

namespace PO.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TestsController : ControllerBase
  {
    private readonly PurchaseQuoteTestService testService;

    public TestsController(PurchaseQuoteTestService testService)
    {
      this.testService = testService;
    }

    [HttpPost]
    public IActionResult ApprovePurchaseQuote()
    {
      this.testService.Approve();


      return Ok();
    }
  }
}
