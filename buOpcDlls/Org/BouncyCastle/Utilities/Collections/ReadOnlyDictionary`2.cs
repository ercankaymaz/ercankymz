// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Collections.ReadOnlyDictionary`2
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Utilities.Collections;

internal abstract class ReadOnlyDictionary<K, V> : 
  IDictionary<K, V>,
  ICollection<KeyValuePair<K, V>>,
  IEnumerable<KeyValuePair<K, V>>,
  IEnumerable
{
  public V this[K key]
  {
    get => this.Lookup(key);
    set => throw new NotSupportedException();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  public bool IsReadOnly => true;

  public void Add(K key, V value) => throw new NotSupportedException();

  public void Add(KeyValuePair<K, V> item) => throw new NotSupportedException();

  public void Clear() => throw new NotSupportedException();

  public bool Remove(K key) => throw new NotSupportedException();

  public bool Remove(KeyValuePair<K, V> item) => throw new NotSupportedException();

  public abstract bool Contains(KeyValuePair<K, V> item);

  public abstract bool ContainsKey(K key);

  public abstract void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex);

  public abstract int Count { get; }

  public abstract IEnumerator<KeyValuePair<K, V>> GetEnumerator();

  public abstract ICollection<K> Keys { get; }

  public abstract bool TryGetValue(K key, out V value);

  public abstract ICollection<V> Values { get; }

  protected abstract V Lookup(K key);
}
