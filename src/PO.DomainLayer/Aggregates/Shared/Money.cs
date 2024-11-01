using Innova.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Aggregates.Shared
{
  public class Money : ValueObject
  {
    public decimal Amount { get; init; }

    public string Currency { get; init; }

    public override string ToString() // 500 TL
    {
      return $"{Amount} {Currency}";
    }


    private Money(decimal amount,string currency)
    {
      Amount = amount;
      Currency = currency;
    }

    public static Money Create(decimal amount, string curreny)
    {
      return new Money(amount, curreny);
    }

    public static Money operator +(Money m1, Money m2)
    {
      ArgumentNullException.ThrowIfNull(m1);
      ArgumentNullException.ThrowIfNull(m2);

      var sum = Money.Create(m1.Amount + m2.Amount,m1.Currency);

      return sum;
    }

    public static Money operator -(Money m1, Money m2)
    {
      ArgumentNullException.ThrowIfNull(m1);
      ArgumentNullException.ThrowIfNull(m2);

      var substract = Money.Create(m1.Amount - m2.Amount, m1.Currency);

      return substract;
    }
    public static bool operator <=(Money m1, Money m2)
    {
      ArgumentNullException.ThrowIfNull(m1);
      ArgumentNullException.ThrowIfNull(m2);

      return m1.Amount <= m2.Amount;
    }

    public static bool operator >=(Money m1, Money m2)
    {
      ArgumentNullException.ThrowIfNull(m1);
      ArgumentNullException.ThrowIfNull(m2);

      return m1.Amount >= m2.Amount;
    }

    public static Money Zero(string currency)
    {
      return new Money(0, currency);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Currency;
      yield return Amount;
    }
  }
}
