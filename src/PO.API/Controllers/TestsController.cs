using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PO.API.Dtos;
using PO.DomainLayer.Aggregates.PO;
using PO.DomainLayer.Aggregates.PQ;
using PO.DomainLayer.Aggregates.PR;
using PO.DomainLayer.Aggregates.Shared;
using PO.PersistanceLayer.EF;

namespace PO.API.Controllers
{
    [Route("api/[controller]")]
  [ApiController]
  public class TestsController : ControllerBase
  {
    private readonly PurchaseQuoteTestService testService;
    private readonly PoDbContext db;
    private readonly IPurchaseQuoteRepository purchaseQuoteRepository;
    private readonly IPurchaseOrderRepository purchaseOrderRepository;
    public TestsController(PurchaseQuoteTestService testService, PoDbContext db, IPurchaseQuoteRepository purchaseQuoteRepository, IPurchaseOrderRepository purchaseOrderRepository)
    {
      this.testService = testService;
      this.db = db;
      this.purchaseQuoteRepository = purchaseQuoteRepository;
      this.purchaseOrderRepository = purchaseOrderRepository;
    }

    [HttpPost]
    public IActionResult ApprovePurchaseQuote()
    {
      this.db.PurchaseRequests.Find();

      this.testService.Approve();


      return Ok();
    }

    [HttpPost("findPurchaseRequestWithQuotes")]
    public IActionResult findPruchaseRequest(Guid PurchaseRequestId)
    {

      var response = this.db.PurchaseRequests
        .Include(x=> x.Items)
        .Include(x => x.Quotes)
        .FirstOrDefault(x => x.Id == PurchaseRequestId);



      return Ok(response);
    }

    [HttpPost("createRequest")]
    public IActionResult CreatePurchaseRequest()
    {

      var money = Money.Create(500000, "TL");
      var request = new PurchaseRequest(money,"15xPC");

      request.AddItem(PurchaseRequestItem.Create("Mouse", 2));
      request.AddItem(PurchaseRequestItem.Create("Klavye", 3));

      


      this.db.PurchaseRequests.Add(request);
      this.db.SaveChanges();


      return Ok();
    }

    [HttpPost("{PurchaseRequestId}/addQuote")]
    public IActionResult AddQuoteToRequest(Guid PurchaseRequestId, [FromBody] CreatePurchaseQuoteDto request)
    {
      var pq = new PurchaseQuote(PurchaseRequestId, Money.Create(request.Amount, request.Currency));

      this.db.PurchaseQuotes.Add(pq);
      this.db.SaveChanges();

      return Ok();
    }


    [HttpPost("{PurchaseQuoteId}/approve")]
    public IActionResult ApproveQuote(Guid PurchaseQuoteId)
    {

      //var q = db.PurchaseQuotes.Find(PurchaseQuoteId);
      //q.OnApprove(); // eklenmiş olan event

      var q =  this.purchaseQuoteRepository.FindById(PurchaseQuoteId);
      q.OnApprove();

      this.db.PurchaseQuotes.Update(q); // Change Tracker burada ilgili entity yakalayacak
      this.db.SaveChanges(); // fırlatılacak.

      return Ok();
    }

    [HttpGet("findPurchaseOrder/{PurchaseOrderId}")]
    public IActionResult FindPurchaseOrderAggregate(Guid PurchaseOrderId)
    {
      var response = this.purchaseOrderRepository.FindById(PurchaseOrderId);

      return Ok(response);
    }
  }
}
