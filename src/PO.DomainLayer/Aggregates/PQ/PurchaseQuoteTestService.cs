using MediatR;
using PO.DomainLayer.Aggregates.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Aggregates.PQ
{
  // PurchaseQoute Approve Simülasyon
  public class PurchaseQuoteTestService
  {
    private readonly IMediator mediator;
    // private PurcaseRequestrepo prRepo
    // private PurchaseQuoteRepo pqRepo
    // private PurchaseOrderRepo poRepo

    public PurchaseQuoteTestService(IMediator mediator)
    {
      this.mediator = mediator;
    }

    public void Approve()
    {
      var purchaseRequestId = Guid.NewGuid();
      var money = Money.Create(5000, "TL");

      var pq = new PurchaseQuote(purchaseRequestId, money);
      pq.OnApprove();

      // Repo.Add();

      // var q = pqRepo.find();
      // q.Status = Approved;
      // pqRepo.update(q);
      // pqRepo.save();

      // var po = new PO();
      // po.status = Submitted;
      // poRepo.create(po);
      // poRepo.save();

      // var req = pRRepo.find();
      // req.status = Completed;
      // pRRepo.update(req);
      // prRepo.save();



      // veritabanına kaydetmeden önce eventleri fırlattığımız kısım.
      // PreSave adımında eventleri fırlatıp, aggregate nesnelerini statelerini güncelleriz.
      pq.events.ToList().ForEach(@event =>
      {
        this.mediator.Publish(@event).Wait();
      });

      Console.Out.WriteLine("Veri tabanına kayıt gerçekleşti \n");

      // unitOfWork.Save();

    }

  }
}
