using PO.DomainLayer.Aggregates.PQ;
using PO.DomainLayer.Aggregates.Shared;
using PO.DomainLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Aggregates.PR
{

  // Entity, Davranışlar ile süreci yürütsün.
  public class PurchaseRequest : AggregateRoot
  {

    public PurchaseRequestStatus Status { get; private set; }
    public Money Budget { get; init; }



    // unidirectional association önerilir.
    // ReadOnly olarak tutmamızın sebebi ise, amaç code-defensing, add veya remove gibi methodlar ile aggregate bozucak şekilde kodların engellenmesini sağmak.
    public IReadOnlyList<PurchaseQuote> Quotes { get; private set; } // Include olarak bağlayıp aggregate bu şekilde oluşturuyoruz.


    public string Description { get; init; } // 2x mouse, 1 x kalem

    /// <summary>
    /// </summary>
    /// <param name="budget">Bütçe</param>
    /// <param name="description">Satın Alınacak olan kalemler</param>
    public PurchaseRequest(Money budget, string description)
    {
      Status = PurchaseRequestStatus.Submitted; // Veritabanına ilk işaretlenecek State
      Budget = budget; // Bütçe
      ArgumentNullException.ThrowIfNull(description);
      Description = description;
    }

    public PurchaseRequest() { }

    /// <summary>
    /// Purchase Order sürecine girince state değiştirmek için çağırılacak olan method
    /// </summary>
    public void OnCompleted()
    {
      Status = PurchaseRequestStatus.Completed;


      //if (Status == PurchaseRequestStatus.Submitted)
      //{
      //  Status = PurchaseRequestStatus.Completed;
      //}
      //else if (Status == PurchaseRequestStatus.Canceled)
      //{
      //  Status = PurchaseRequestStatus.Submitted;
      //  Console.Out.WriteLine("Canceled State olduğundan önce Submitted olarak işaretlenip sonra completed'a çevrildi");
      //  OnCompleted();
      //}
    }

    /// <summary>
    /// Purchase Order Iptal sürecine girerse bu methodu çağıracağım.
    /// </summary>
    public void OnCanceled()
    {
      if (Status == PurchaseRequestStatus.Submitted || Status == PurchaseRequestStatus.Completed)
      {
        Status = PurchaseRequestStatus.Canceled;
      }
      else
      {
        throw new Exception("Zaten Request Iptal durumunda");
      }

    }

  }
}
