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
  // Handler Eventlerden altıkları bilgiye göre süreci işleten servislerimiz.

  public class CreatePurchaseOrderHandler : INotificationHandler<TransformAsOrderEvent>
  {
    private readonly IPurchaseOrderRepository purchaseOrderRepository;

    public CreatePurchaseOrderHandler(IPurchaseOrderRepository purchaseOrderRepository)
    {
      this.purchaseOrderRepository = purchaseOrderRepository;
    }

    public Task Handle(TransformAsOrderEvent notification, CancellationToken cancellationToken)
    {
      var po = new PurchaseOrder(notification.PurchaseRequestId, notification.PurchaseQuoteId);

      this.purchaseOrderRepository.Add(po); // Repository için bu nesneyi Added State olarak uyguladığımı belirtim. Daha Db Kayıt yok. Onu en sonda UnitOfWork üzerinden merkezi olarak yöneteceğiz.


      return Console.Out.WriteAsync("Create PO Süreci \n");
    }
  }
}
