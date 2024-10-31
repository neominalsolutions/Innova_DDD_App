using MediatR;
using PO.DomainLayer.Aggregates.PQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Handlers
{
  // PurchaseQuoteAggregate
  public class RejectPurchaseQuoteNotApprovedHandler : INotificationHandler<TransformAsOrderEvent>
  {
    public Task Handle(TransformAsOrderEvent notification, CancellationToken cancellationToken)
    {
      return Console.Out.WriteLineAsync($"{notification.PurchaseQuoteId} Approved oldu {notification.PurchaseRequestId} tanımlanmış tüm diğer Quoteları Rejected Yap");
    }
  }
}
