using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innova.Domain.Core
{
  // Root Nesne, Repository sınıfları ve Event güdümlü geliştirme bu sınıf üzerinden yapılır.
  public abstract class AggregateRoot:Entity
  {
    public readonly IList<INotification> events = [];

    /// <summary>
    /// Aggregate root içerisinde başka bir aggregate'e event üzerinden haberleşmek için kullanacağız.
    /// </summary>
    /// <param name="event"></param>
    public void AddEvent(INotification @event)
    {
      events.Add(@event);
    }

    /// <summary>
    /// eklenen bir eventin geri alınması gereken durumlarda kullanabiliriz.
    /// </summary>
    /// <param name="event"></param>
    public void RemoveEvent(INotification @event)
    {
      events.Remove(@event);
    }

    /// <summary>
    /// InMemory olarak Aggregate Root nesnesi üzerindeki Eventleri Temizler; Eventler çalıştıktan sonra ramden silinsin diye kullanırız.
    /// </summary>
    public void ClearEvents()
    {
      events.Clear();
    }

  }
}
