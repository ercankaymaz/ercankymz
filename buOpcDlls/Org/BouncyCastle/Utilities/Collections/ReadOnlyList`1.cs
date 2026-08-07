// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Collections.ReadOnlyList`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Utilities.Collections;

internal abstract class ReadOnlyList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
  public T this[int index]
  {
    get => this.Lookup(index);
    set => throw new NotSupportedException();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  public bool IsReadOnly => true;

  public void Add(T item) => throw new NotSupportedException();

  public void Clear() => throw new NotSupportedException();

  public void Insert(int index, T item) => throw new NotSupportedException();

  public bool Remove(T item) => throw new NotSupportedException();

  public void RemoveAt(int index) => throw new NotSupportedException();

  public abstract bool Contains(T item);

  public abstract void CopyTo(T[] array, int arrayIndex);

  public abstract int Count { get; }

  public abstract IEnumerator<T> GetEnumerator();

  public abstract int IndexOf(T item);

  protected abstract T Lookup(int index);
}
