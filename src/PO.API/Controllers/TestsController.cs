﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PO.API.Data;
using PO.API.Dtos;
using PO.DomainLayer.Aggregates.PQ;
using PO.DomainLayer.Aggregates.PR;
using PO.DomainLayer.Aggregates.Shared;

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


    [HttpPost("createRequest")]
    public IActionResult CreatePurchaseRequest()
    {
      var money = Money.Create(500000, "TL");
      var request = new PurchaseRequest(money,"15xPC");

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
  }
}
