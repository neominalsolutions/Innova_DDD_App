using Innova.Infra.Core;
using PO.DomainLayer.Aggregates.PR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Aggregates.PQ
{
 

  public class PurchaseQuoteService
  {
    private readonly IPurchaseQuoteRepository purchaseQuoteRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly PurchaseQuoteApprovalDomainService purchaseQuoteApprovalDomainService;

    public PurchaseQuoteService(IPurchaseQuoteRepository purchaseQuoteRepository, IUnitOfWork unitOfWork, PurchaseQuoteApprovalDomainService purchaseQuoteApprovalDomainService)
    {
      this.purchaseQuoteRepository = purchaseQuoteRepository;
      this.unitOfWork = unitOfWork;
      this.purchaseQuoteApprovalDomainService = purchaseQuoteApprovalDomainService;
    }


    public void Create(PurchaseQuote purchaseQuote)
    {
      this.purchaseQuoteRepository.Add(purchaseQuote);
      this.unitOfWork.Commit(); // veri tabanına gönder.
    }

    /// <summary>
    /// Bussiness Rule Request Bütçesini aşan bir quote Approve edilemez.
    /// </summary>
    /// <param name="PurchaseQuoteId"></param>
    public void Approve(Guid PurchaseQuoteId)
    {
      var quote = this.purchaseQuoteRepository.FindById(PurchaseQuoteId);

      var approved = this.purchaseQuoteApprovalDomainService.CheckApprovalRule(quote);

      if (approved)
      {
        quote.OnApprove();
        this.purchaseQuoteRepository.Update(quote);
        this.unitOfWork.Commit();
      }
      else
      {
        throw new Exception("Bu Teklif Approve edilemez");
      }

    }
  }
}
