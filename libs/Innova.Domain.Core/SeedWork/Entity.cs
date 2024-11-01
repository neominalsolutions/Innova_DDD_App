using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innova.Domain.Core
{
  // Root Entity ve Child Entity kalıtım alıcak.
  public abstract class Entity
  {
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; }

    protected Entity()
    {
      Id = Guid.NewGuid();
      CreatedAt = DateTime.UtcNow;
    }
  }
}
