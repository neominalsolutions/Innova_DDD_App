using PO.DomainLayer.SeedWork;

namespace PO.API.Data
{
  // merkezi olarak bir commit noktası oluşturmak.
  // Repositorylerin amacı ise ilgili entitylerin statelerinin save öncesi Added,Deleted,Modified şeklinde takibini yapmak.
  public class PoUnitOfWork : IUnitOfWork
  {
    private readonly PoDbContext db;
    private readonly ILogger<PoUnitOfWork> logger;

    public PoUnitOfWork(PoDbContext db, ILogger<PoUnitOfWork> logger)
    {
      this.db = db;
      this.logger = logger;
    }

    public void Commit()
    {
      try
      {
        this.db.SaveChanges(); // auto commit
      }
      catch (Exception ex)
      {
        this.logger.LogError(ex.Message);
      }

    }
  }
}
