using MediatR;
using PO.DomainLayer.Aggregates.PO;
using PO.DomainLayer.Aggregates.PQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Handlers
{
  public class RejectAllPurchaseQuoteHandler : INotificationHandler<PurchaseOrderCanceled>
  {
    private readonly IPurchaseQuoteRepository purchaseQuoteRepository;

    public RejectAllPurchaseQuoteHandler(IPurchaseQuoteRepository purchaseQuoteRepository)
    {
      this.purchaseQuoteRepository = purchaseQuoteRepository;
    }

    public Task Handle(PurchaseOrderCanceled notification, CancellationToken cancellationToken)
    {
      var allPurchaseQuotes = this.purchaseQuoteRepository.Find(x => x.PurchaseRequestId == notification.PurchaseRequestId);

      allPurchaseQuotes.ToList().ForEach((item) =>
      {
        item.OnReject();
        this.purchaseQuoteRepository.Update(item);
      });

      return Console.Out.WriteLineAsync($"{notification.PurchaseRequestId} ait tüm quoteları rejected yap \n");
    }
  }
}
