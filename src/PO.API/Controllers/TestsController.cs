using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PO.API.Data;
using PO.DomainLayer.Aggregates.PQ;

namespace PO.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TestsController : ControllerBase
  {
    private readonly PurchaseQuoteTestService testService;
    private readonly PoDbContext db;

    public TestsController(PurchaseQuoteTestService testService, PoDbContext db)
    {
      this.testService = testService;
      this.db = db;
    }

    [HttpPost]
    public IActionResult ApprovePurchaseQuote()
    {
      this.db.PurchaseRequests.Find();

      this.testService.Approve();


      return Ok();
    }
  }
}
