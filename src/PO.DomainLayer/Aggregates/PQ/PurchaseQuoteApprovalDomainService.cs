using PO.DomainLayer.Aggregates.PR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Aggregates.PQ
{

  public class PurchaseQuoteApprovalDomainService
  {
    private readonly IPurchaseRequestRepository purchaseRequestRepository;

    public PurchaseQuoteApprovalDomainService(IPurchaseRequestRepository purchaseRequestRepository)
    {
      this.purchaseRequestRepository = purchaseRequestRepository;
    }

    public bool CheckApprovalRule(PurchaseQuote purchaseQuote)
    {
      var request = this.purchaseRequestRepository.FindById(purchaseQuote.PurchaseRequestId);

      ArgumentNullException.ThrowIfNull(request);

      // Money ValueObject Nesnesini Operatörler ile birlikte kullanacak şekilde yazalım.
      if (request.Budget.Amount >= purchaseQuote.Cost.Amount)
      {
        return true;
      }

      return false;
    }

  }
}
