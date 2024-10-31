using PO.DomainLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Aggregates.PO
{
  public class PurchaseOrderStatus : Enumeration
  {
    public static PurchaseOrderStatus Submitted = new(100, "Submitted");
    public static PurchaseOrderStatus Canceled = new(200, "Canceled");
    public PurchaseOrderStatus(int value, string text) : base(value, text)
    {
    }
  }
}
