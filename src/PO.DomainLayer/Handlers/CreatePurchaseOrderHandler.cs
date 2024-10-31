using MediatR;
using PO.DomainLayer.Aggregates.PQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Handlers
{
  // Handler Eventlerden altıkları bilgiye göre süreci işleten servislerimiz.

  public class CreatePurchaseOrderHandler : INotificationHandler<TransformAsOrderEvent>
  {
    public Task Handle(TransformAsOrderEvent notification, CancellationToken cancellationToken)
    {
       return Console.Out.WriteAsync("Create PO Süreci");
    }
  }
}
