// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.ActivityTagsCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Diagnostics;

[NullableContext(1)]
[Nullable(0)]
[ComVisible(true)]
public class ActivityTagsCollection : 
  IDictionary<string, object>,
  ICollection<KeyValuePair<string, object>>,
  IEnumerable<KeyValuePair<string, object>>,
  IEnumerable
{
  private List<KeyValuePair<string, object>> _list = new List<KeyValuePair<string, object>>();

  public ActivityTagsCollection()
  {
  }

  public ActivityTagsCollection([Nullable(new byte[] {1, 0, 1, 2})] IEnumerable<KeyValuePair<string, object>> list)
  {
    if (list == null)
      throw new ArgumentNullException(nameof (list));
    foreach (KeyValuePair<string, object> keyValuePair in list)
    {
      if (keyValuePair.Key != null)
        this[keyValuePair.Key] = keyValuePair.Value;
    }
  }

  [Nullable(2)]
  public object this[string key]
  {
    [return: Nullable(2)] get
    {
      int index = this.FindIndex(key);
      return index >= 0 ? this._list[index].Value : (object) null;
    }
    [param: Nullable(2)] set
    {
      int index = key != null ? this.FindIndex(key) : throw new ArgumentNullException(nameof (key));
      if (value == null)
      {
        if (index < 0)
          return;
        this._list.RemoveAt(index);
      }
      else if (index >= 0)
        this._list[index] = new KeyValuePair<string, object>(key, value);
      else
        this._list.Add(new KeyValuePair<string, object>(key, value));
    }
  }

  public ICollection<string> Keys
  {
    get
    {
      List<string> keys = new List<string>(this._list.Count);
      foreach (KeyValuePair<string, object> keyValuePair in this._list)
        keys.Add(keyValuePair.Key);
      return (ICollection<string>) keys;
    }
  }

  [Nullable(new byte[] {1, 2})]
  public ICollection<object> Values
  {
    [return: Nullable(new byte[] {1, 2})] get
    {
      List<object> values = new List<object>(this._list.Count);
      foreach (KeyValuePair<string, object> keyValuePair in this._list)
        values.Add(keyValuePair.Value);
      return (ICollection<object>) values;
    }
  }

  public bool IsReadOnly => false;

  public int Count => this._list.Count;

  public void Add(string key, [Nullable(2)] object value)
  {
    if (key == null)
      throw new ArgumentNullException(nameof (key));
    if (this.FindIndex(key) >= 0)
      throw new InvalidOperationException(System.System.Diagnostics.DiagnosticSource3462135.SR.Format(System.System.Diagnostics.DiagnosticSource3462135.SR.KeyAlreadyExist, (object) key));
    this._list.Add(new KeyValuePair<string, object>(key, value));
  }

  public void Add([Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> item)
  {
    if (item.Key == null)
      throw new ArgumentNullException(nameof (item));
    if (this.FindIndex(item.Key) >= 0)
      throw new InvalidOperationException(System.System.Diagnostics.DiagnosticSource3462135.SR.Format(System.System.Diagnostics.DiagnosticSource3462135.SR.KeyAlreadyExist, (object) item.Key));
    this._list.Add(item);
  }

  public void Clear() => this._list.Clear();

  public bool Contains([Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> item)
  {
    return this._list.Contains(item);
  }

  public bool ContainsKey(string key) => this.FindIndex(key) >= 0;

  public void CopyTo([Nullable(new byte[] {1, 0, 1, 2})] KeyValuePair<string, object>[] array, int arrayIndex)
  {
    this._list.CopyTo(array, arrayIndex);
  }

  IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
  {
    return (IEnumerator<KeyValuePair<string, object>>) new ActivityTagsCollection.Enumerator(this._list);
  }

  public ActivityTagsCollection.Enumerator GetEnumerator()
  {
    return new ActivityTagsCollection.Enumerator(this._list);
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return (IEnumerator) new ActivityTagsCollection.Enumerator(this._list);
  }

  public bool Remove(string key)
  {
    int index = key != null ? this.FindIndex(key) : throw new ArgumentNullException(nameof (key));
    if (index < 0)
      return false;
    this._list.RemoveAt(index);
    return true;
  }

  public bool Remove([Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> item)
  {
    return this._list.Remove(item);
  }

  public bool TryGetValue(string key, [Nullable(2)] out object value)
  {
    int index = this.FindIndex(key);
    if (index >= 0)
    {
      value = this._list[index].Value;
      return true;
    }
    value = (object) null;
    return false;
  }

  private int FindIndex(string key)
  {
    for (int index = 0; index < this._list.Count; ++index)
    {
      if (this._list[index].Key == key)
        return index;
    }
    return -1;
  }

  [NullableContext(0)]
  public struct Enumerator : IEnumerator<KeyValuePair<string, object>>, IDisposable, IEnumerator
  {
    private List<KeyValuePair<string, object>>.Enumerator _enumerator;

    internal Enumerator(List<KeyValuePair<string, object>> list)
    {
      this._enumerator = list.GetEnumerator();
    }

    [Nullable(new byte[] {0, 1, 2})]
    public KeyValuePair<string, object> Current
    {
      [return: Nullable(new byte[] {0, 1, 2})] get => this._enumerator.Current;
    }

    [Nullable(1)]
    object IEnumerator.Current => ((IEnumerator) this._enumerator).Current;

    public void Dispose() => this._enumerator.Dispose();

    public bool MoveNext() => this._enumerator.MoveNext();

    void IEnumerator.Reset() => ((IEnumerator) this._enumerator).Reset();
  }
}
