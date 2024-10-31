using PO.DomainLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Aggregates.PQ
{


  public class PurchaseQuoteStatus : Enumeration
  {
    public static PurchaseQuoteStatus Submitted = new(100, "Submitted");
    public static PurchaseQuoteStatus Approved = new(200, "Approved");
    public static PurchaseQuoteStatus Rejected = new(300, "Rejected");
    public PurchaseQuoteStatus(int value, string text) : base(value, text)
    {
    }
  }
}
