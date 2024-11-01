using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Aggregates.PR
{
  public class AddPurchaseRequestItemException:Exception
  {
        public AddPurchaseRequestItemException(string message):base(message)
        {
            
        }
    }
}
