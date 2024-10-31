﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using PO.DomainLayer.Aggregates.PO;
using PO.DomainLayer.Aggregates.PQ;
using PO.DomainLayer.Aggregates.PR;
using PO.DomainLayer.SeedWork;

namespace PO.API.Data
{
  public class PoDbContext : DbContext
  {
    // Sadece Aggregate Root olan sınıfları dışarıdan Repository üzerinden erişim yapılsın diye tanımlıyoruz
    // ValueObject veya Enumeration sınıfları DbContext içerisine maplenmez.

    private readonly IMediator mediator;
    public DbSet<PurchaseRequest> PurchaseRequests { get; set; }

    public DbSet<PurchaseQuote> PurchaseQuotes { get; set; }

    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }


    public PoDbContext(DbContextOptions<PoDbContext> options, IMediator mediator) : base(options)
    {
      this.mediator = mediator;
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


    public override int SaveChanges()
    {
      // git changeTracker üzerinden içine event eklenmiş olan nesneleri bul
      var dbEntries = this.ChangeTracker.Entries<AggregateRoot>().Where(x => x.Entity.events != null && x.Entity.events.Any());

      var events = dbEntries.SelectMany(x => x.Entity.events).ToList();

      events.ForEach((@event) =>
      {
        mediator.Publish(@event).Wait();
      });

      dbEntries.ToList().ForEach((item) =>
      {
        item.Entity.ClearEvents(); // Tüm In Memory Eventleri Temizle
      });


      // Pre Save eventleri fırlatacağımız bölge.

      return base.SaveChanges();
    }
  }
}
