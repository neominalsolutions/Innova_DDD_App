using MediatR;
using PO.DomainLayer.Aggregates.PO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Handlers
{
  public class RejectAllPurchaseQuoteHandler : INotificationHandler<PurchaseOrderCanceled>
  {
    public Task Handle(PurchaseOrderCanceled notification, CancellationToken cancellationToken)
    {
      return Console.Out.WriteLineAsync($"{notification.PurchaseRequestId} ait tüm quoteları rejected yap \n");
    }
  }
}
