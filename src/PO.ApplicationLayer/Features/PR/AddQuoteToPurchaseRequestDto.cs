using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.ApplicationLayer.Features.PR
{
  public record AddQuoteToPurchaseRequestDto(Guid PurchaseRequestId,decimal Cost,string Currency):IRequest
  {

  }
  
}
