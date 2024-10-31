using Microsoft.EntityFrameworkCore;
using PO.DomainLayer.Aggregates.PO;
using PO.DomainLayer.Aggregates.PQ;
using PO.DomainLayer.Aggregates.PR;

namespace PO.API.Data
{
  public class PoDbContext : DbContext
  {
    // Sadece Aggregate Root olan sınıfları dışarıdan Repository üzerinden erişim yapılsın diye tanımlıyoruz
    // ValueObject veya Enumeration sınıfları DbContext içerisine maplenmez.
    public DbSet<PurchaseRequest> PurchaseRequests { get; set; }

    public DbSet<PurchaseQuote> PurchaseQuotes { get; set; }

    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }


    public PoDbContext(DbContextOptions<PoDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Purchase Request 

      // ValueObject ve Enumeration Sınıfları için mapping işlemleri yapıyoruz
      modelBuilder.Entity<PurchaseRequest>().OwnsOne(x => x.Budget).Property(x => x.Amount).HasColumnName("Budget_Amount");
      modelBuilder.Entity<PurchaseRequest>().OwnsOne(x => x.Budget).Property(x => x.Currency).HasColumnName("Budget_Currency");

      modelBuilder.Entity<PurchaseRequest>().OwnsOne(x => x.Status).Property(x => x.Text).HasColumnName("Status_Text");
      modelBuilder.Entity<PurchaseRequest>().OwnsOne(x => x.Status).Property(x => x.Value).HasColumnName("Status_Value");

      // Purchase Quote 

      modelBuilder.Entity<PurchaseQuote>().OwnsOne(x => x.Cost).Property(x => x.Amount).HasColumnName("Cost_Amount");
      modelBuilder.Entity<PurchaseQuote>().OwnsOne(x => x.Cost).Property(x => x.Currency).HasColumnName("Cost_Currency");


      modelBuilder.Entity<PurchaseQuote>().OwnsOne(x => x.Status).Property(x => x.Text).HasColumnName("Status_Text");
      modelBuilder.Entity<PurchaseQuote>().OwnsOne(x => x.Status).Property(x => x.Value).HasColumnName("Status_Value");

      // PurchaseOrder

      modelBuilder.Entity<PurchaseOrder>().OwnsOne(x => x.Status).Property(x => x.Text).HasColumnName("Status_Text");
      modelBuilder.Entity<PurchaseOrder>().OwnsOne(x => x.Status).Property(x => x.Value).HasColumnName("Status_Value");


      base.OnModelCreating(modelBuilder);
    }
  }
}
