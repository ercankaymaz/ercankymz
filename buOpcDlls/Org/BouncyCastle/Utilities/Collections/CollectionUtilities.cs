// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Collections.CollectionUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Utilities.Collections;

public abstract class CollectionUtilities
{
  public static void CollectMatches<T>(
    ICollection<T> matches,
    ISelector<T> selector,
    IEnumerable<IStore<T>> stores)
  {
    if (matches == null)
      throw new ArgumentNullException(nameof (matches));
    if (stores == null)
      return;
    foreach (IStore<T> store in stores)
    {
      if (store != null)
      {
        foreach (T enumerateMatch in store.EnumerateMatches(selector))
          matches.Add(enumerateMatch);
      }
    }
  }

  public static IStore<T> CreateStore<T>(IEnumerable<T> contents)
  {
    return (IStore<T>) new StoreImpl<T>(contents);
  }

  public static T GetFirstOrNull<T>(IEnumerable<T> e) where T : class
  {
    if (e != null)
    {
      using (IEnumerator<T> enumerator = e.GetEnumerator())
      {
        if (enumerator.MoveNext())
          return enumerator.Current;
      }
    }
    return default (T);
  }

  public static T GetValueOrKey<T>(IDictionary<T, T> d, T k)
  {
    T obj;
    return !d.TryGetValue(k, out obj) ? k : obj;
  }

  public static V GetValueOrNull<K, V>(IDictionary<K, V> d, K k) where V : class
  {
    V v;
    return !d.TryGetValue(k, out v) ? default (V) : v;
  }

  public static IEnumerable<T> Proxy<T>(IEnumerable<T> e)
  {
    return (IEnumerable<T>) new EnumerableProxy<T>(e);
  }

  public static ICollection<T> ReadOnly<T>(ICollection<T> c)
  {
    return (ICollection<T>) new ReadOnlyCollectionProxy<T>(c);
  }

  public static IDictionary<K, V> ReadOnly<K, V>(IDictionary<K, V> d)
  {
    return (IDictionary<K, V>) new ReadOnlyDictionaryProxy<K, V>(d);
  }

  public static IList<T> ReadOnly<T>(IList<T> l) => (IList<T>) new ReadOnlyListProxy<T>(l);

  public static ISet<T> ReadOnly<T>(ISet<T> s) => (ISet<T>) new ReadOnlySetProxy<T>(s);

  public static bool Remove<K, V>(IDictionary<K, V> d, K k, out V v)
  {
    if (!d.TryGetValue(k, out v))
      return false;
    d.Remove(k);
    return true;
  }

  public static T RequireNext<T>(IEnumerator<T> e)
  {
    return e.MoveNext() ? e.Current : throw new InvalidOperationException();
  }

  public static string ToString<T>(IEnumerable<T> c)
  {
    IEnumerator<T> enumerator = c.GetEnumerator();
    if (!enumerator.MoveNext())
      return "[]";
    StringBuilder stringBuilder = new StringBuilder("[");
    stringBuilder.Append((object) enumerator.Current);
    while (enumerator.MoveNext())
    {
      stringBuilder.Append(", ");
      stringBuilder.Append((object) enumerator.Current);
    }
    stringBuilder.Append(']');
    return stringBuilder.ToString();
  }
}
