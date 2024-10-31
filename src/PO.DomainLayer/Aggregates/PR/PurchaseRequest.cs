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

    public string Description { get; init; }

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
      if (Status.Value == PurchaseRequestStatus.Submitted.Value)
      {
        Status = PurchaseRequestStatus.Completed;
      }
      else if (Status.Value == PurchaseRequestStatus.Canceled.Value)
      {
        Status = PurchaseRequestStatus.Submitted;
        Console.Out.WriteLine("Canceled State olduğundan önce Submitted olarak işaretlenip sonra completed'a çevrildi");
        OnCompleted();
      }
    }

    /// <summary>
    /// Purchase Order Iptal sürecine girerse bu methodu çağıracağım.
    /// </summary>
    public void OnCanceled()
    {
      if (Status.Value == PurchaseRequestStatus.Submitted.Value || Status.Value == PurchaseRequestStatus.Completed.Value)
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
