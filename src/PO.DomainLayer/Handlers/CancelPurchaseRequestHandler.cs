using MediatR;
using PO.DomainLayer.Aggregates.PO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Handlers
{
  public class CancelPurchaseRequestHandler : INotificationHandler<PurchaseOrderCanceled>
  {
    public Task Handle(PurchaseOrderCanceled notification, CancellationToken cancellationToken)
    {
      return Console.Out.WriteLineAsync($"{notification.PurchaseRequestId} is Canceled \n");
    }
  }
}
