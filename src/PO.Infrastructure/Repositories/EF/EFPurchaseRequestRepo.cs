

using Innova.EF.Infra.Core;
using PO.DomainLayer.Aggregates.PR;
using PO.PersistanceLayer.EF;

namespace PO.Infrastructure
{
  // Data katmanı ile Domain katmanının EF üzerinden haberleşmesi için Adapter sınıfı yazdık.
  public class EFPurchaseRequestRepo : EFRepository<PoDbContext, PurchaseRequest>, IPurchaseRequestRepository
  {
    public EFPurchaseRequestRepo(PoDbContext dbContext) : base(dbContext)
    {
    }
  }
}
