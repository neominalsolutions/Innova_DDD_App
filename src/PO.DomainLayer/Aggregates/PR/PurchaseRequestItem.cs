using Innova.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Aggregates.PR
{
  public class PurchaseRequestItem : Entity
  {
    public string Name { get; set; } // Mouse
    public int Quantity { get; set; } // 2x

    // public Guid PurchaseRequestId { get; set; }

    public PurchaseRequestItem() // EF Migration için gerekli
    {

    }

    private PurchaseRequestItem(string name, int quantity)
    {
      ArgumentNullException.ThrowIfNull(name);
      Quantity = quantity < 0 ? 1 : quantity;

      Name = name;
      Quantity = quantity;
    }

    public static PurchaseRequestItem Create(string name, int quantity)
    {
      return new PurchaseRequestItem(name,quantity);
    }
  }
}
