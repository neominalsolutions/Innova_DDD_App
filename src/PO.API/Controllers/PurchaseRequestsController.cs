using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PO.ApplicationLayer.Features.PR;

namespace PO.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PurchaseRequestsController : ControllerBase
  {
    // routing, tüm uygulamaya ait featurelar meditor üzerinden application katmanına yönlendiriliyor.
    private readonly IMediator mediator;
    // private readOnly PurchaseRequestService ps;

    public PurchaseRequestsController(IMediator mediator)
    {
      this.mediator = mediator;
    }

    /// <summary>
    /// Mal Talebi oluşturma süreci
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePurchaseRequestDto request)
    {
      // Request Gönderme işlemlerinde Send methodu kullanılır
      // Event fırlatma işlemlerinde Publish kullanılıyor.
      await this.mediator.Send(request); // requesthandler'a isteği yönedirir.

      return Ok();
    }

    /// <summary>
    /// Request'e Code Ekleme
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("addQuote")]
    public async Task<IActionResult> AddQuote([FromBody] AddQuoteToPurchaseRequestDto request)
    {
      await this.mediator.Send(request);

      return Ok();
    }


  }
}
