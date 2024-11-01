using Innova.Infra.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Aggregates.PO
{
  // Hexagonal Architecture  göre Domain bir alt yada üst katman ile haberleşip bir işlemi gerçekleştirecek ise bunu interface Portlar üzerinden yapar.
  public interface IPurchaseOrderRepository:IRepository<PurchaseOrder>
  {
  }
}
