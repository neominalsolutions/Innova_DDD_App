using MediatR;
using PO.DomainLayer.Aggregates.PQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Handlers
{
  // PurchaseRequest Completed Sürecisine çevirmek için kullanılan hizmet.
  public class CompletePurchaseRequestHandler : INotificationHandler<TransformAsOrderEvent>
  {
    public Task Handle(TransformAsOrderEvent notification, CancellationToken cancellationToken)
    {
      return Console.Out.WriteAsync("Purchase Request Completed oldu");

    }
  }
}
