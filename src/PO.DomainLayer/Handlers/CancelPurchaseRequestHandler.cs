using MediatR;
using PO.DomainLayer.Aggregates.PO;
using PO.DomainLayer.Aggregates.PR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Handlers
{
  public class CancelPurchaseRequestHandler : INotificationHandler<PurchaseOrderCanceled>
  {
    private readonly IPurchaseRequestRepository purchaseRequestRepository;

    public CancelPurchaseRequestHandler(IPurchaseRequestRepository purchaseRequestRepository)
    {
      this.purchaseRequestRepository = purchaseRequestRepository;
    }

    public Task Handle(PurchaseOrderCanceled notification, CancellationToken cancellationToken)
    {
      var request = this.purchaseRequestRepository.FindById(notification.PurchaseRequestId);
      request.OnCanceled();

      this.purchaseRequestRepository.Update(request);

      return Console.Out.WriteLineAsync($"{notification.PurchaseRequestId} is Canceled \n");
    }
  }
}
