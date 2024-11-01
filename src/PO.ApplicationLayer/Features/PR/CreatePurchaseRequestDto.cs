using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.ApplicationLayer.Features.PR
{
  public record PurchaseRequestItemDto(string Name,int Quantity);

  public record CreatePurchaseRequestDto(string Description,decimal budgetAmount,string budgetCurrency, PurchaseRequestItemDto[] Items):IRequest;
  
}
