using PO.DomainLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Aggregates.PO
{
 

  public class PurchaseOrder : AggregateRoot
  {
    public Guid PurchaseRequestId { get; init; }

    public Guid PurchaseQuoteId { get; init; }

    public PurchaseOrderStatus Status { get; private set; }


    public PurchaseOrder(Guid purchaseRequestId, Guid purchaseQuoteId)
    {
      PurchaseRequestId = purchaseRequestId;
      PurchaseQuoteId = purchaseQuoteId;
      Status = PurchaseOrderStatus.Submitted;
    }


    public void OnCancel()
    {
      Status = PurchaseOrderStatus.Canceled;
      AddEvent(new PurchaseOrderCanceled(PurchaseRequestId));
    }


  }
}
