


using Innova.Domain.Core;
using Innova.Infra.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Innova.EF.Infra.Core
{
  public abstract class EFRepository<TDbContext, TAggregateRoot> : IRepository<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
    where TDbContext : DbContext
  {
    protected TDbContext db;
    protected DbSet<TAggregateRoot> table;

    protected EFRepository(TDbContext dbContext)
    {
      this.db = dbContext;
      this.table = this.db.Set<TAggregateRoot>();
    }

    public virtual void Add(TAggregateRoot aggregateRoot)
    {
      this.table.Add(aggregateRoot); // Entity State Added
    }

    public virtual IEnumerable<TAggregateRoot> Find(Expression<Func<TAggregateRoot, bool>> expression)
    {
      return this.table.Where(expression).AsEnumerable();
    }

    public virtual TAggregateRoot FindById(Guid Id)
    {
      return this.table.Find(Id);
    }

    public virtual void Remove(TAggregateRoot aggregateRoot)
    {
      this.table.Remove(aggregateRoot);  // Entity State Deleted olsun.
    }

    public virtual void Update(TAggregateRoot aggregateRoot)
    {
      this.table.Update(aggregateRoot); // Entity State Modifield 
    }

    public virtual void UpdateBulk(TAggregateRoot[] aggregateRoot)
    {
      this.table.UpdateRange(aggregateRoot);
    }
  }
}
