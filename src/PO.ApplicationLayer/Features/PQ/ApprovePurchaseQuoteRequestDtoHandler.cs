using MediatR;
using PO.DomainLayer.Aggregates.PQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.ApplicationLayer.Features.PQ
{
  public class ApprovePurchaseQuoteRequestDtoHandler : IRequestHandler<ApprovePurchaseQuoteRequestDto>
  {
    private readonly PurchaseQuoteService purchaseQuoteService;


    public ApprovePurchaseQuoteRequestDtoHandler(PurchaseQuoteService purchaseQuoteService)
    {
      this.purchaseQuoteService = purchaseQuoteService;
    }

    public Task Handle(ApprovePurchaseQuoteRequestDto request, CancellationToken cancellationToken)
    {

      this.purchaseQuoteService.Approve(request.PurchaseQuoteId);
      // Not: Domain eventler sonrası kayıt başarılı olduysa application katmanında Integration Event fırlatara süreci Microservices dağıtalım.
      // 

      return Task.CompletedTask;
    }
  }
}
