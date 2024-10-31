using PO.DomainLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Aggregates.PR
{
  public class PurchaseRequestStatus : Enumeration
  {
    public static PurchaseRequestStatus Submitted => new(100, "Submitted");
    public static PurchaseRequestStatus Completed => new(200, "Completed");

    public static PurchaseRequestStatus Canceled => new(300, "Canceled");

    public PurchaseRequestStatus(int value, string text) : base(value, text)
    {
    }
  }
}
