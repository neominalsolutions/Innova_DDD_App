using MediatR;
using PO.DomainLayer.Aggregates.PR;
using PO.DomainLayer.Aggregates.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.ApplicationLayer.Features.PR
{
  // Amaç application katmanın kullanıcıdan gönderilen request nesnesini işleyip domain katmanına aktaracak bir koordinatör katman geliştirme. Use-Caseler bu application katmanında bulunuyor.
  public class CreatePurchaseRequestDtoHandler : IRequestHandler<CreatePurchaseRequestDto>
  {
    private readonly PurchaseRequestService purchaseRequestService;


    public CreatePurchaseRequestDtoHandler(PurchaseRequestService purchaseRequestService)
    {
      this.purchaseRequestService = purchaseRequestService;
    }

    public Task Handle(CreatePurchaseRequestDto request, CancellationToken cancellationToken)
    {

      // request nesnelernin Validation Kontrolü yapıalabilir.
      // AutoMapper ile gelen request Entity'lere de maplenebilir.

      PurchaseRequest p = new(Money.Create(request.budgetAmount, request.budgetCurrency), request.Description);

      request.Items.ToList().ForEach((item) =>
      {
        p.AddItem(PurchaseRequestItem.Create(item.Name, item.Quantity));
      });

      purchaseRequestService.Create(p);

      return Task.CompletedTask;

      // save işlemi sonrası başka MS event fırlatma
      // bildirim gönderme mail atma

    }
  }
}
