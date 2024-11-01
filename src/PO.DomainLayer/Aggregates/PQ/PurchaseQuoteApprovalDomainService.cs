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

      // Bu kod bloğu yerine aşağıdaki gibi ValueObject'e < > operatörleri ekletik.
      //if (request.Budget.Amount >= purchaseQuote.Cost.Amount)
      //{
      //  return true;
      //}

      //var total = (request.Budget + purchaseQuote.Cost);

      // Money ValueObject Nesnesini Operatörler ile birlikte kullanacak şekilde yazalım.
      if (request.Budget >= purchaseQuote.Cost)
      {
        return true;
      }

      return false;
    }

  }
}
