using MediatR;
using PO.DomainLayer.Aggregates.PQ;
using PO.DomainLayer.Aggregates.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.ApplicationLayer.Features.PR
{
  public class AddQuoteToPurchaseRequestDtoHandler : IRequestHandler<AddQuoteToPurchaseRequestDto>
  {
    private readonly PurchaseQuoteService purchaseQuoteService;

    public AddQuoteToPurchaseRequestDtoHandler(PurchaseQuoteService purchaseQuoteService)
    {
      this.purchaseQuoteService = purchaseQuoteService;
    }

    public Task Handle(AddQuoteToPurchaseRequestDto request, CancellationToken cancellationToken)
    {

      PurchaseQuote pq = new(request.PurchaseRequestId,Money.Create(request.Cost,request.Currency));

      this.purchaseQuoteService.Create(pq);

      return Task.CompletedTask;
    }
  }
}
