using Innova.Domain.Core;
using Innova.Infra.Core;
using Microsoft.EntityFrameworkCore;
using PO.ApplicationLayer.Features.PR;
using PO.DomainLayer.Aggregates.PO;
using PO.DomainLayer.Aggregates.PQ;
using PO.DomainLayer.Aggregates.PR;
using PO.DomainLayer.Aggregates.Shared;
using PO.Infrastructure;
using PO.PersistanceLayer.EF;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Test servis üzerinden süreci In Memory olarak test etmek için kullandýk.
builder.Services.AddScoped<PurchaseQuoteTestService>();

// Tüm Handlerlar Register olur.
builder.Services.AddMediatR(opt =>
{
  var applicationLayer = Assembly.GetAssembly(typeof(CreatePurchaseRequestDto));
  var domainLayer = Assembly.GetAssembly(typeof(PurchaseOrder));



  opt.RegisterServicesFromAssemblies(applicationLayer,domainLayer);


});

// Repository Servislerin eklenmesi
builder.Services.AddScoped<IPurchaseRequestRepository, EFPurchaseRequestRepo>();
builder.Services.AddScoped<IPurchaseQuoteRepository, EFPurchaseQuoteRepo>();
builder.Services.AddScoped<IPurchaseOrderRepository, EFPurchaseOrderRepo>();
builder.Services.AddScoped<IUnitOfWork, PoUnitOfWork>();



builder.Services.AddScoped<PurchaseQuoteApprovalDomainService>();
builder.Services.AddScoped<PurchaseRequestService>();
builder.Services.AddScoped<PurchaseQuoteService>();

// Veritabaný Baðlantý ayarlarý
builder.Services.AddDbContext<PoDbContext>(opt =>
{
  opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn2"), opt =>
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
