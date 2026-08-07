// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Collections.ReadOnlyDictionaryProxy`2
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Utilities.Collections;

internal class ReadOnlyDictionaryProxy<K, V> : ReadOnlyDictionary<K, V>
{
  private readonly IDictionary<K, V> m_target;

  internal ReadOnlyDictionaryProxy(IDictionary<K, V> target)
  {
    this.m_target = target != null ? target : throw new ArgumentNullException(nameof (target));
  }

  public override bool Contains(KeyValuePair<K, V> item) => this.m_target.Contains(item);

  public override bool ContainsKey(K key) => this.m_target.ContainsKey(key);

  public override void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
  {
    this.m_target.CopyTo(array, arrayIndex);
  }

  public override int Count => this.m_target.Count;

  public override IEnumerator<KeyValuePair<K, V>> GetEnumerator() => this.m_target.GetEnumerator();

  public override ICollection<K> Keys
  {
    get => (ICollection<K>) new ReadOnlyCollectionProxy<K>(this.m_target.Keys);
  }

  public override bool TryGetValue(K key, out V value) => this.m_target.TryGetValue(key, out value);

  public override ICollection<V> Values
  {
    get => (ICollection<V>) new ReadOnlyCollectionProxy<V>(this.m_target.Values);
  }

  protected override V Lookup(K key) => this.m_target[key];
}
