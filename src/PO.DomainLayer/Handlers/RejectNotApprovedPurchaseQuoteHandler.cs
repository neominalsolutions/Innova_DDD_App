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
  // Tek görevleri Aggregatelerin doğru statelerde oluşturulmasını sağlamak.
  public class RejectNotApprovedPurchaseQuoteHandler : INotificationHandler<TransformAsOrderEvent>
  {
    private readonly IPurchaseQuoteRepository purchaseQuoteRepository;
    


    public RejectNotApprovedPurchaseQuoteHandler(IPurchaseQuoteRepository purchaseQuoteRepository)
    {
      this.purchaseQuoteRepository = purchaseQuoteRepository;
    }

    public Task Handle(TransformAsOrderEvent notification, CancellationToken cancellationToken)
    {

      var notApprovedQuotes = this.purchaseQuoteRepository.Find(x => x.PurchaseRequestId == notification.PurchaseRequestId).ToList();


     

      foreach (var item in notApprovedQuotes)
      {
        if(item.Id != notification.PurchaseQuoteId)
        {
          item.OnReject();
          //this.purchaseQuoteRepository.Update(item);
        }
      }

      this.purchaseQuoteRepository.UpdateBulk(notApprovedQuotes.ToArray());

      return Console.Out.WriteLineAsync($"{notification.PurchaseQuoteId} Approved oldu {notification.PurchaseRequestId} tanımlanmış tüm diğer Quoteları Rejected Yap \n");
    }
  }
}
