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

    // Aggregate Root içerisinde bir child entity var ise bunun yönetimi aggregate root nesnesine bırakılmalıdır. Yani addItem veya RemoveItem gibi davranışlar, aggregate root üzerinden yönetilmelidir.

    private List<PurchaseRequestItem> items = []; // boş bir liste oluşturduk
    public IReadOnlyList<PurchaseRequestItem> Items => items;

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
     
      if (Status.Equals(PurchaseRequestStatus.Submitted))
      {
        Status = PurchaseRequestStatus.Completed;
      }
      else if (Status.Equals(PurchaseRequestStatus.Canceled))
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
      if (Status.Equals(PurchaseRequestStatus.Submitted) || Status.Equals(PurchaseRequestStatus.Completed))
      {
        Status = PurchaseRequestStatus.Canceled;
      }
      else
      {
        throw new Exception("Zaten Request Iptal durumunda");
      }

    }


    /// <summary>
    /// Request için Talep edilen Itemların eklenmesi
    /// </summary>
    /// <param name="item"></param>
    /// <exception cref="AddPurchaseRequestItemException"></exception>
    public void AddItem(PurchaseRequestItem item)
    {
      // 1. bir request içerisindeki talep edilen itemlar, birim başına en fazla 5 adeti geçemesin
      // 2. bir request içerisinde en falza 10 kalem ürün için satın alma talebi oluşturulabilir.
      // 

      items.ForEach((item) =>
      {
        if (item.Quantity > 5)
        {
          throw new AddPurchaseRequestItemException("Bir satın alma kaleminde en fazla 5 adet ürün talep edilebilir");
        }

      });


      if (Items.Count() < 10)
      {
        items.Add(item);
      }
      else
      {
        throw new AddPurchaseRequestItemException("Satın alma talebinde en fazla 10 kalem ürün satın alınabilir");
      }

    }
  }
}
