// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReadOnlyList`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class ReadOnlyList<T> : 
  IList<T>,
  ICollection<T>,
  IEnumerable<T>,
  IEnumerable,
  IList,
  ICollection
{
  private IList<T> m_list;

  public ReadOnlyList(IList<T> list)
  {
    this.m_list = list;
    if (this.m_list != null)
      return;
    this.m_list = (IList<T>) Array.Empty<T>();
  }

  public ReadOnlyList(IList<T> list, bool makeCopy)
  {
    if (list != null & makeCopy)
    {
      T[] objArray = new T[list.Count];
      for (int index = 0; index < objArray.Length; ++index)
        objArray[index] = list[index];
      list = (IList<T>) objArray;
    }
    this.m_list = list;
    if (this.m_list != null)
      return;
    this.m_list = (IList<T>) Array.Empty<T>();
  }

  public int Count => this.m_list.Count;

  public void Add(T item) => throw new NotSupportedException();

  public void Clear() => throw new NotSupportedException();

  public bool Contains(T item) => this.m_list.Contains(item);

  public void CopyTo(T[] array, int arrayIndex) => this.m_list.CopyTo(array, arrayIndex);

  public bool IsReadOnly => true;

  public bool Remove(T item) => throw new NotSupportedException();

  public int IndexOf(T item) => this.m_list.IndexOf(item);

  public void Insert(int index, T item) => throw new NotSupportedException();

  public void RemoveAt(int index) => throw new NotSupportedException();

  public T this[int index]
  {
    get => this.m_list[index];
    set => throw new NotSupportedException();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.m_list.GetEnumerator();

  public IEnumerator<T> GetEnumerator() => this.m_list.GetEnumerator();

  public static ReadOnlyList<T> ToList(T[] values) => new ReadOnlyList<T>((IList<T>) values);

  public static implicit operator ReadOnlyList<T>(T[] values)
  {
    return new ReadOnlyList<T>((IList<T>) values);
  }

  int IList.Add(object value) => throw new NotImplementedException();

  void IList.Clear() => throw new NotImplementedException();

  bool IList.Contains(object value) => this.Contains((T) value);

  int IList.IndexOf(object value) => this.IndexOf((T) value);

  void IList.Insert(int index, object value) => throw new NotImplementedException();

  bool IList.IsFixedSize => true;

  bool IList.IsReadOnly => true;

  void IList.Remove(object value) => throw new NotImplementedException();

  void IList.RemoveAt(int index) => throw new NotImplementedException();

  object IList.this[int index]
  {
    get => (object) this[index];
    set => this[index] = (T) value;
  }

  void ICollection.CopyTo(Array array, int index) => this.CopyTo((T[]) array, index);

  int ICollection.Count => this.Count;

  bool ICollection.IsSynchronized => false;

  object ICollection.SyncRoot => (object) false;
}
