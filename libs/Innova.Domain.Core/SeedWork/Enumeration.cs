using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Innova.Domain.Core
{
  public abstract class Enumeration : IComparable
  {
    public string Text { get; private set; } // Submitted
    public int Value { get; private set; } // 200
    protected Enumeration(int value, string text)
    {
      Value = value;
      Text = text;
    }
    public override string ToString() => Text; // Submitted
    public static IEnumerable<TEnumeration> GetFields<TEnumeration>() where TEnumeration : Enumeration
    {
      var fields = typeof(TEnumeration).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

      return fields.Select(f => f.GetValue(null)).Cast<TEnumeration>();
    }

    /// <summary>
    /// 2 farklı Enumeration Nesnesnin type ve value eşitliğine baktığımız kısım.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
      if (obj is not Enumeration otherValue)
      {
        return false;
      }
      var typeMatches = GetType().Equals(obj.GetType());
      var valueMatches = Value.Equals(otherValue.Value);
      return typeMatches && valueMatches;
    }

    public override int GetHashCode() => Value.GetHashCode();

    /// <summary>
    /// Value olarak 2 farklı Enumeration arasında değer farkı varmıya bakar.
    /// </summary>
    /// <param name="firstValue"></param>
    /// <param name="secondValue"></param>
    /// <returns></returns>
    public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
    {
      var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
      return absoluteDifference;
    }
    /// <summary>
    /// Value üzerinden Nesne olarak ilgili tipi döndürür.
    /// </summary>
    /// <typeparam name="TEnumeration"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static TEnumeration FromValue<TEnumeration>(int value) where TEnumeration : Enumeration
    {
      var matchingItem = Parse<TEnumeration, int>(value, "value", item => item.Value == value);
      return matchingItem;
    }
    /// <summary>
    /// Text değeri üzerinden Enumeration Nesnesine erişmemiz gereken durumlarda kullanabiliriz.
    /// </summary>
    /// <typeparam name="TEnumeration"></typeparam>
    /// <param name="displayName"></param>
    /// <returns></returns>
    public static TEnumeration FromDisplayName<TEnumeration>(string displayName) where TEnumeration : Enumeration
    {
      var matchingItem = Parse<TEnumeration, string>(displayName, "display name", item => item.Text == displayName);
      return matchingItem;
    }
    /// <summary>
    /// İki farklı Enumeration değeri birbirine parse ediliyor mu
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <param name="value"></param>
    /// <param name="description"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    /// <exception cref="FormatException"></exception>
    private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
    {
      var matchingItem = GetFields<T>().FirstOrDefault(predicate);

      if (matchingItem is null)
        throw new FormatException($"'{value}' is not a valid {description} in {typeof(T)}");

      return matchingItem;
    }
    /// <summary>
    /// İki farklı Enumeration sınıfı value olarak birbirlerine eşit mi.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(object other) => Value.CompareTo(((Enumeration)other).Value);
  }
}
