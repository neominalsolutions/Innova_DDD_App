using Microsoft.EntityFrameworkCore;
using PO.API.Data;
using PO.DomainLayer.Aggregates.PO;
using PO.DomainLayer.Aggregates.PQ;
using PO.DomainLayer.Aggregates.PR;
using PO.DomainLayer.Aggregates.Shared;
using PO.DomainLayer.SeedWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Test servis �zerinden s�reci In Memory olarak test etmek i�in kulland�k.
builder.Services.AddScoped<PurchaseQuoteTestService>();

// T�m Handlerlar Register olur.
builder.Services.AddMediatR(opt =>
{
  opt.RegisterServicesFromAssemblyContaining<AggregateRoot>();
});

// Repository Servislerin eklenmesi
builder.Services.AddScoped<IPurchaseRequestRepository, EFPurchaseRequestRepo>();
builder.Services.AddScoped<IPurchaseQuoteRepository, EFPurchaseQuoteRepo>();
builder.Services.AddScoped<IPurchaseOrderRepository, EFPurchaseOrderRepo>();


// Veritaban� Ba�lant� ayarlar�
builder.Services.AddDbContext<PoDbContext>(opt =>
{
  opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"), opt =>
  {
    opt.EnableRetryOnFailure();
  });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
