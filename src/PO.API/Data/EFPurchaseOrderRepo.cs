using PO.DomainLayer.Aggregates.PO;

namespace PO.API.Data
{
  public class EFPurchaseOrderRepo : EFRepository<PoDbContext, PurchaseOrder>, IPurchaseOrderRepository
  {
    public EFPurchaseOrderRepo(PoDbContext dbContext) : base(dbContext)
    {
    }
  }
}
