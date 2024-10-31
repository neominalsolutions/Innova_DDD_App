using PO.DomainLayer.Aggregates.PR;

namespace PO.API.Data
{
  // Data katmanı ile Domain katmanının EF üzerinden haberleşmesi için Adapter sınıfı yazdık.
  public class EFPurchaseRequestRepo : EFRepository<PoDbContext, PurchaseRequest>, IPurchaseRequestRepository
  {
    public EFPurchaseRequestRepo(PoDbContext dbContext) : base(dbContext)
    {
    }
  }
}
