using PO.DomainLayer.SeedWork;
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

    public PurchaseQuoteService(IPurchaseQuoteRepository purchaseQuoteRepository, IUnitOfWork unitOfWork)
    {
      this.purchaseQuoteRepository = purchaseQuoteRepository;
      this.unitOfWork = unitOfWork;
    }



    public void Create(PurchaseQuote purchaseQuote)
    {
      this.purchaseQuoteRepository.Add(purchaseQuote);
      this.unitOfWork.Commit(); // veri tabanına gönder.
    }

  }
}
