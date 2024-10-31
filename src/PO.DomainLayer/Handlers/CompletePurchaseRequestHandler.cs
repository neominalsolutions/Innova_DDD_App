using MediatR;
using PO.DomainLayer.Aggregates.PQ;
using PO.DomainLayer.Aggregates.PR;
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
    private readonly IPurchaseRequestRepository purchaseRequestRepository;

    public CompletePurchaseRequestHandler(IPurchaseRequestRepository purchaseRequestRepository)
    {
      this.purchaseRequestRepository = purchaseRequestRepository;
    }

    public Task Handle(TransformAsOrderEvent notification, CancellationToken cancellationToken)
    {
      var purchaseRequest = this.purchaseRequestRepository.FindById(notification.PurchaseRequestId);
      purchaseRequest.OnCompleted();

      this.purchaseRequestRepository.Update(purchaseRequest); // Modified olarak Update sorgusu gönderilecek şekilde state işaretle.

      return Console.Out.WriteAsync("Purchase Request Completed oldu \n");

    }
  }
}
