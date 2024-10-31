using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.SeedWork
{
  // Repository sadece AggregateRoot olabilir.
  public interface IRepository<TAggregateRoot> 
    where TAggregateRoot:AggregateRoot
  {

    void Add(TAggregateRoot aggregateRoot);
    void Update(TAggregateRoot aggregateRoot);

    void Remove(TAggregateRoot aggregateRoot);

    TAggregateRoot FindById(Guid Id);

    IEnumerable<TAggregateRoot> Find(Expression<Func<TAggregateRoot, bool>> expression);


  }
}
