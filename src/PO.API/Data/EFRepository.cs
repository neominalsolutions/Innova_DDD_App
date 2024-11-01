using Microsoft.EntityFrameworkCore;
using PO.DomainLayer.SeedWork;
using System.Linq.Expressions;

namespace PO.API.Data
{
  public abstract class EFRepository<TDbContext, TAggregateRoot> : IRepository<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
    where TDbContext : DbContext
  {
    private TDbContext db;
    private DbSet<TAggregateRoot> table;

    protected EFRepository(TDbContext dbContext)
    {
      this.db = dbContext;
      this.table = this.db.Set<TAggregateRoot>();
    }

    public void Add(TAggregateRoot aggregateRoot)
    {
      this.table.Add(aggregateRoot); // Entity State Added
    }

    public IEnumerable<TAggregateRoot> Find(Expression<Func<TAggregateRoot, bool>> expression)
    {
      return this.table.Where(expression).AsEnumerable();
    }

    public TAggregateRoot FindById(Guid Id)
    {
      return this.table.Find(Id);
    }

    public void Remove(TAggregateRoot aggregateRoot)
    {
      this.table.Remove(aggregateRoot);  // Entity State Deleted olsun.
    }

    public void Update(TAggregateRoot aggregateRoot)
    {
      this.table.Update(aggregateRoot); // Entity State Modifield 
    }

    public void UpdateBulk(TAggregateRoot[] aggregateRoot)
    {
      this.table.UpdateRange(aggregateRoot);
    }
  }
}
