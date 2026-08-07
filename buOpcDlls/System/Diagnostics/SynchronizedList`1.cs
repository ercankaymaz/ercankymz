// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.SynchronizedList`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;

#nullable disable
namespace System.Diagnostics;

internal sealed class SynchronizedList<T>
{
  private readonly List<T> _list;
  private uint _version;

  public SynchronizedList() => this._list = new List<T>();

  public void Add(T item)
  {
    lock (this._list)
    {
      this._list.Add(item);
      ++this._version;
    }
  }

  public bool AddIfNotExist(T item)
  {
    lock (this._list)
    {
      if (this._list.Contains(item))
        return false;
      this._list.Add(item);
      ++this._version;
      return true;
    }
  }

  public bool Remove(T item)
  {
    lock (this._list)
    {
      if (!this._list.Remove(item))
        return false;
      ++this._version;
      return true;
    }
  }

  public int Count => this._list.Count;

  public void EnumWithFunc<TParent>(
    ActivitySource.Function<T, TParent> func,
    ref ActivityCreationOptions<TParent> data,
    ref ActivitySamplingResult samplingResult,
    ref ActivityCreationOptions<ActivityContext> dataWithContext)
  {
    uint version = this._version;
    int index = 0;
    while (index < this._list.Count)
    {
      T obj;
      lock (this._list)
      {
        if ((int) version != (int) this._version)
        {
          version = this._version;
          index = 0;
          continue;
        }
        obj = this._list[index];
        ++index;
      }
      func(obj, ref data, ref samplingResult, ref dataWithContext);
    }
  }

  public void EnumWithAction(Action<T, object> action, object arg)
  {
    uint version = this._version;
    int index = 0;
    while (index < this._list.Count)
    {
      T obj;
      lock (this._list)
      {
        if ((int) version != (int) this._version)
        {
          version = this._version;
          index = 0;
          continue;
        }
        obj = this._list[index];
        ++index;
      }
      action(obj, arg);
    }
  }
}
