// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.DictionaryWrapper`2
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Threading;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal class DictionaryWrapper<[Nullable(2)] TKey, [Nullable(2)] TValue> : 
  IDictionary<TKey, TValue>,
  ICollection<KeyValuePair<TKey, TValue>>,
  IEnumerable<KeyValuePair<TKey, TValue>>,
  IEnumerable,
  IWrappedDictionary,
  IDictionary,
  ICollection
{
  [Nullable(2)]
  private readonly IDictionary _dictionary;
  [Nullable(new byte[] {2, 1, 1})]
  private readonly IDictionary<TKey, TValue> _genericDictionary;
  [Nullable(new byte[] {2, 1, 1})]
  private readonly IReadOnlyDictionary<TKey, TValue> _readOnlyDictionary;
  [Nullable(2)]
  private object _syncRoot;

  public DictionaryWrapper(IDictionary dictionary)
  {
    ValidationUtils.ArgumentNotNull((object) dictionary, nameof (dictionary));
    this._dictionary = dictionary;
  }

  public DictionaryWrapper(IDictionary<TKey, TValue> dictionary)
  {
    ValidationUtils.ArgumentNotNull((object) dictionary, nameof (dictionary));
    this._genericDictionary = dictionary;
  }

  public DictionaryWrapper(IReadOnlyDictionary<TKey, TValue> dictionary)
  {
    ValidationUtils.ArgumentNotNull((object) dictionary, nameof (dictionary));
    this._readOnlyDictionary = dictionary;
  }

  internal IDictionary<TKey, TValue> GenericDictionary => this._genericDictionary;

  public void Add(TKey key, TValue value)
  {
    if (this._dictionary != null)
    {
      this._dictionary.Add((object) key, (object) value);
    }
    else
    {
      if (this._genericDictionary == null)
        throw new NotSupportedException();
      this._genericDictionary.Add(key, value);
    }
  }

  public bool ContainsKey(TKey key)
  {
    if (this._dictionary != null)
      return this._dictionary.Contains((object) key);
    return this._readOnlyDictionary != null ? this._readOnlyDictionary.ContainsKey(key) : this.GenericDictionary.ContainsKey(key);
  }

  public ICollection<TKey> Keys
  {
    get
    {
      if (this._dictionary != null)
        return (ICollection<TKey>) this._dictionary.Keys.Cast<TKey>().ToList<TKey>();
      return this._readOnlyDictionary != null ? (ICollection<TKey>) this._readOnlyDictionary.Keys.ToList<TKey>() : this.GenericDictionary.Keys;
    }
  }

  public bool Remove(TKey key)
  {
    if (this._dictionary != null)
    {
      if (!this._dictionary.Contains((object) key))
        return false;
      this._dictionary.Remove((object) key);
      return true;
    }
    if (this._readOnlyDictionary != null)
      throw new NotSupportedException();
    return this.GenericDictionary.Remove(key);
  }

  public bool TryGetValue(TKey key, [Nullable(2)] out TValue value)
  {
    if (this._dictionary != null)
    {
      if (!this._dictionary.Contains((object) key))
      {
        value = default (TValue);
        return false;
      }
      value = (TValue) this._dictionary[(object) key];
      return true;
    }
    if (this._readOnlyDictionary != null)
      throw new NotSupportedException();
    return this.GenericDictionary.TryGetValue(key, out value);
  }

  public ICollection<TValue> Values
  {
    get
    {
      if (this._dictionary != null)
        return (ICollection<TValue>) this._dictionary.Values.Cast<TValue>().ToList<TValue>();
      return this._readOnlyDictionary != null ? (ICollection<TValue>) this._readOnlyDictionary.Values.ToList<TValue>() : this.GenericDictionary.Values;
    }
  }

  public TValue this[TKey key]
  {
    get
    {
      if (this._dictionary != null)
        return (TValue) this._dictionary[(object) key];
      return this._readOnlyDictionary != null ? this._readOnlyDictionary[key] : this.GenericDictionary[key];
    }
    set
    {
      if (this._dictionary != null)
      {
        this._dictionary[(object) key] = (object) value;
      }
      else
      {
        if (this._readOnlyDictionary != null)
          throw new NotSupportedException();
        this.GenericDictionary[key] = value;
      }
    }
  }

  public void Add([Nullable(new byte[] {0, 1, 1})] KeyValuePair<TKey, TValue> item)
  {
    if (this._dictionary != null)
    {
      ((IList) this._dictionary).Add((object) item);
    }
    else
    {
      if (this._readOnlyDictionary != null)
        throw new NotSupportedException();
      this._genericDictionary?.Add(item);
    }
  }

  public void Clear()
  {
    if (this._dictionary != null)
    {
      this._dictionary.Clear();
    }
    else
    {
      if (this._readOnlyDictionary != null)
        throw new NotSupportedException();
      this.GenericDictionary.Clear();
    }
  }

  public bool Contains([Nullable(new byte[] {0, 1, 1})] KeyValuePair<TKey, TValue> item)
  {
    if (this._dictionary != null)
      return ((IList) this._dictionary).Contains((object) item);
    return this._readOnlyDictionary != null ? this._readOnlyDictionary.Contains<KeyValuePair<TKey, TValue>>(item) : this.GenericDictionary.Contains(item);
  }

  public void CopyTo([Nullable(new byte[] {1, 0, 1, 1})] KeyValuePair<TKey, TValue>[] array, int arrayIndex)
  {
    if (this._dictionary != null)
    {
      IDictionaryEnumerator enumerator = this._dictionary.GetEnumerator();
      try
      {
        while (enumerator.MoveNext())
        {
          DictionaryEntry entry = enumerator.Entry;
          array[arrayIndex++] = new KeyValuePair<TKey, TValue>((TKey) entry.Key, (TValue) entry.Value);
        }
      }
      finally
      {
        if (enumerator is IDisposable disposable)
          disposable.Dispose();
      }
    }
    else
    {
      if (this._readOnlyDictionary != null)
        throw new NotSupportedException();
      this.GenericDictionary.CopyTo(array, arrayIndex);
    }
  }

  public int Count
  {
    get
    {
      if (this._dictionary != null)
        return this._dictionary.Count;
      return this._readOnlyDictionary != null ? this._readOnlyDictionary.Count : this.GenericDictionary.Count;
    }
  }

  public bool IsReadOnly
  {
    get
    {
      if (this._dictionary != null)
        return this._dictionary.IsReadOnly;
      return this._readOnlyDictionary != null || this.GenericDictionary.IsReadOnly;
    }
  }

  public bool Remove([Nullable(new byte[] {0, 1, 1})] KeyValuePair<TKey, TValue> item)
  {
    if (this._dictionary != null)
    {
      if (!this._dictionary.Contains((object) item.Key))
        return true;
      if (!object.Equals(this._dictionary[(object) item.Key], (object) item.Value))
        return false;
      this._dictionary.Remove((object) item.Key);
      return true;
    }
    if (this._readOnlyDictionary != null)
      throw new NotSupportedException();
    return ((ICollection<KeyValuePair<TKey, TValue>>) this.GenericDictionary).Remove(item);
  }

  [return: Nullable(new byte[] {1, 0, 1, 1})]
  public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
  {
    if (this._dictionary != null)
      return this._dictionary.Cast<DictionaryEntry>().Select<DictionaryEntry, KeyValuePair<TKey, TValue>>((Func<DictionaryEntry, KeyValuePair<TKey, TValue>>) ([NullableContext(0)] (de) => new KeyValuePair<TKey, TValue>((TKey) de.Key, (TValue) de.Value))).GetEnumerator();
    return this._readOnlyDictionary != null ? this._readOnlyDictionary.GetEnumerator() : this.GenericDictionary.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  void IDictionary.Add(object key, [Nullable(2)] object value)
  {
    if (this._dictionary != null)
    {
      this._dictionary.Add(key, value);
    }
    else
    {
      if (this._readOnlyDictionary != null)
        throw new NotSupportedException();
      this.GenericDictionary.Add((TKey) key, (TValue) value);
    }
  }

  [Nullable(2)]
  object IDictionary.this[object key]
  {
    [return: Nullable(2)] get
    {
      if (this._dictionary != null)
        return this._dictionary[key];
      return this._readOnlyDictionary != null ? (object) this._readOnlyDictionary[(TKey) key] : (object) this.GenericDictionary[(TKey) key];
    }
    [param: Nullable(2)] set
    {
      if (this._dictionary != null)
      {
        this._dictionary[key] = value;
      }
      else
      {
        if (this._readOnlyDictionary != null)
          throw new NotSupportedException();
        this.GenericDictionary[(TKey) key] = (TValue) value;
      }
    }
  }

  IDictionaryEnumerator IDictionary.GetEnumerator()
  {
    if (this._dictionary != null)
      return this._dictionary.GetEnumerator();
    return this._readOnlyDictionary != null ? (IDictionaryEnumerator) new DictionaryWrapper<TKey, TValue>.DictionaryEnumerator<TKey, TValue>(this._readOnlyDictionary.GetEnumerator()) : (IDictionaryEnumerator) new DictionaryWrapper<TKey, TValue>.DictionaryEnumerator<TKey, TValue>(this.GenericDictionary.GetEnumerator());
  }

  bool IDictionary.Contains(object key)
  {
    if (this._genericDictionary != null)
      return this._genericDictionary.ContainsKey((TKey) key);
    return this._readOnlyDictionary != null ? this._readOnlyDictionary.ContainsKey((TKey) key) : this._dictionary.Contains(key);
  }

  bool IDictionary.IsFixedSize
  {
    get
    {
      if (this._genericDictionary != null)
        return false;
      return this._readOnlyDictionary != null || this._dictionary.IsFixedSize;
    }
  }

  ICollection IDictionary.Keys
  {
    get
    {
      if (this._genericDictionary != null)
        return (ICollection) this._genericDictionary.Keys.ToList<TKey>();
      return this._readOnlyDictionary != null ? (ICollection) this._readOnlyDictionary.Keys.ToList<TKey>() : this._dictionary.Keys;
    }
  }

  public void Remove(object key)
  {
    if (this._dictionary != null)
    {
      this._dictionary.Remove(key);
    }
    else
    {
      if (this._readOnlyDictionary != null)
        throw new NotSupportedException();
      this.GenericDictionary.Remove((TKey) key);
    }
  }

  ICollection IDictionary.Values
  {
    get
    {
      if (this._genericDictionary != null)
        return (ICollection) this._genericDictionary.Values.ToList<TValue>();
      return this._readOnlyDictionary != null ? (ICollection) this._readOnlyDictionary.Values.ToList<TValue>() : this._dictionary.Values;
    }
  }

  void ICollection.CopyTo(Array array, int index)
  {
    if (this._dictionary != null)
    {
      this._dictionary.CopyTo(array, index);
    }
    else
    {
      if (this._readOnlyDictionary != null)
        throw new NotSupportedException();
      this.GenericDictionary.CopyTo((KeyValuePair<TKey, TValue>[]) array, index);
    }
  }

  bool ICollection.IsSynchronized => this._dictionary != null && this._dictionary.IsSynchronized;

  object ICollection.SyncRoot
  {
    get
    {
      if (this._syncRoot == null)
        Interlocked.CompareExchange(ref this._syncRoot, new object(), (object) null);
      return this._syncRoot;
    }
  }

  public object UnderlyingDictionary
  {
    get
    {
      if (this._dictionary != null)
        return (object) this._dictionary;
      return this._readOnlyDictionary != null ? (object) this._readOnlyDictionary : (object) this.GenericDictionary;
    }
  }

  [Nullable(0)]
  [System.Runtime.CompilerServices.Newtonsoft.Json.IsReadOnly]
  private struct DictionaryEnumerator<[Nullable(2)] TEnumeratorKey, [Nullable(2)] TEnumeratorValue> : 
    IDictionaryEnumerator,
    IEnumerator
  {
    [Nullable(new byte[] {1, 0, 1, 1})]
    private readonly IEnumerator<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> _e;

    public DictionaryEnumerator(
      [Nullable(new byte[] {1, 0, 1, 1})] IEnumerator<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> e)
    {
      ValidationUtils.ArgumentNotNull((object) e, nameof (e));
      this._e = e;
    }

    public DictionaryEntry Entry => (DictionaryEntry) this.Current;

    public object Key => this.Entry.Key;

    [Nullable(2)]
    public object Value
    {
      [NullableContext(2)] get => this.Entry.Value;
    }

    public object Current
    {
      get
      {
        KeyValuePair<TEnumeratorKey, TEnumeratorValue> current = this._e.Current;
        __Boxed<TEnumeratorKey> key = (object) current.Key;
        current = this._e.Current;
        __Boxed<TEnumeratorValue> local = (object) current.Value;
        return (object) new DictionaryEntry((object) key, (object) local);
      }
    }

    public bool MoveNext() => this._e.MoveNext();

    public void Reset() => this._e.Reset();
  }
}
