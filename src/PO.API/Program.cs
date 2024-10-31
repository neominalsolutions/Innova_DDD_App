using PO.DomainLayer.Aggregates.PR;
using PO.DomainLayer.Aggregates.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var money = Money.Zero("TL"); // 0 TL
// money.Currency = "Dolar";
//money.Amount = 15; Immutable çalýþýr. ilk oluþurken init yazdýðýmýzdan sadece constructordan deðer alýr.
var money2 = Money.Create(500, "TL");
var money3 = Money.Create(750, "TL");
var money4 = Money.Create(750, "TL");


PurchaseRequest p1 = new PurchaseRequest(Money.Zero("TL"));
PurchaseRequest p2 = new(Money.Zero("TL"));

Console.Out.WriteLine("Ref Equal" + p1.Equals(p2));







var equal =  money2.Equals(money3);
Console.Out.WriteLine("Money2== Money3 Deðer olarak eþit mi" + equal);

var equal2 = money3.Equals(money4);
Console.Out.WriteLine("Money3 == Money4 Deðer olarak eþit mi" + equal2);






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
