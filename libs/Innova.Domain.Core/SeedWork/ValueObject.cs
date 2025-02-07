﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innova.Domain.Core
{
  /// <summary>
  /// Değer Nesnelerini oluşturmak için kullandığımız base bir sınıf, sınıf içerisindeki propertylerin başka bir değer sınıfına eşit olup olmadığının kontrolü bu sınıf ile yapıyoruz.
  /// </summary>
  public abstract class ValueObject
  {
    protected static bool EqualOperator(ValueObject left, ValueObject right)
    {
      if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
      {
        return false;
      }
      return ReferenceEquals(left, right) || left.Equals(right);
    }

    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
    {
      return !(EqualOperator(left, right));
    }

    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object obj)
    {
      if (obj == null || obj.GetType() != GetType())
      {
        return false;
      }

      var other = (ValueObject)obj;

      return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
      return GetEqualityComponents()
          .Select(x => x != null ? x.GetHashCode() : 0)
          .Aggregate((x, y) => x ^ y);
    }
    // Other utility methods
  }
}
