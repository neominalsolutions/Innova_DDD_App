using PO.DomainLayer.Aggregates.PQ;

namespace PO.API.Data
{
  public class EFPurchaseQuoteRepo : EFRepository<PoDbContext, PurchaseQuote>, IPurchaseQuoteRepository
  {
    public EFPurchaseQuoteRepo(PoDbContext dbContext) : base(dbContext)
    {
    }
  }
}
