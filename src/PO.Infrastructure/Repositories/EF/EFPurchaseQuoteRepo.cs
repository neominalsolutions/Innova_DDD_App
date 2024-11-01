

using Innova.EF.Infra.Core;
using PO.DomainLayer.Aggregates.PQ;
using PO.PersistanceLayer.EF;

namespace PO.Infrastructure
{
  public class EFPurchaseQuoteRepo : EFRepository<PoDbContext, PurchaseQuote>, IPurchaseQuoteRepository
  {
    public EFPurchaseQuoteRepo(PoDbContext dbContext) : base(dbContext)
    {
    }
  }
}
