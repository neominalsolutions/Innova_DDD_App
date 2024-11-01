

using Innova.EF.Infra.Core;
using Microsoft.EntityFrameworkCore;
using PO.DomainLayer.Aggregates.PO;
using PO.PersistanceLayer.EF;

namespace PO.Infrastructure
{
  public class EFPurchaseOrderRepo : EFRepository<PoDbContext, PurchaseOrder>, IPurchaseOrderRepository
  {
    public EFPurchaseOrderRepo(PoDbContext dbContext) : base(dbContext)
    {
    }

    public override PurchaseOrder FindById(Guid Id)
    {
      var entity = this.table.OrderBy(x=> x.CreatedAt)
        .Include(x => x.PurchaseQuote)
        .Include(x => x.PurchaseRequest)
        .ThenInclude(x => x.Items)
        .FirstOrDefault(x => x.Id == Id);

      ArgumentNullException.ThrowIfNull(entity);

      return entity;

     
    }
  }
}
