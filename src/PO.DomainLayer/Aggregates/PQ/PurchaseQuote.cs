using PO.DomainLayer.Aggregates.Shared;
using PO.DomainLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Aggregates.PQ
{

  // Mal satın alma teklifi
  public class PurchaseQuote : AggregateRoot
  {
    public Guid PurchaseRequestId { get; init; }
    public Money Cost { get; init; } // Value Object

    public PurchaseQuoteStatus Status { get; private set; }

    public PurchaseQuote(Guid purchaseRequestId, Money cost)
    {
      PurchaseRequestId = purchaseRequestId;
      Cost = cost;
      Status = PurchaseQuoteStatus.Submitted;
    }

    public PurchaseQuote() { }

    public void OnApprove()
    {
      Status = PurchaseQuoteStatus.Approved;
      // TransformAsOrder Eventi Aggregate Root içerisine ekle.
      AddEvent(new TransformAsOrderEvent(PurchaseRequestId: PurchaseRequestId,
        PurchaseQuoteId: Id));
      // Sürecin başka bir aggregate üzerinden devam etmesi için bir event oluşturduk.
    }

    public void OnReject()
    {
      Status = PurchaseQuoteStatus.Rejected;
    }



  }
}
