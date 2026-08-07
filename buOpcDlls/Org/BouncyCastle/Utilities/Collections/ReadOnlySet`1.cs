// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Collections.ReadOnlySet`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Utilities.Collections;

internal abstract class ReadOnlySet<T> : ISet<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  public bool IsReadOnly => true;

  void ICollection<T>.Add(T item) => throw new NotSupportedException();

  public bool Add(T item) => throw new NotSupportedException();

  public void Clear() => throw new NotSupportedException();

  public void ExceptWith(IEnumerable<T> other) => throw new NotSupportedException();

  public void IntersectWith(IEnumerable<T> other) => throw new NotSupportedException();

  public bool Remove(T item) => throw new NotSupportedException();

  public bool SetEquals(IEnumerable<T> other) => throw new NotSupportedException();

  public void SymmetricExceptWith(IEnumerable<T> other) => throw new NotSupportedException();

  public void UnionWith(IEnumerable<T> other) => throw new NotSupportedException();

  public abstract bool Contains(T item);

  public abstract void CopyTo(T[] array, int arrayIndex);

  public abstract int Count { get; }

  public abstract IEnumerator<T> GetEnumerator();

  public abstract bool IsProperSubsetOf(IEnumerable<T> other);

  public abstract bool IsProperSupersetOf(IEnumerable<T> other);

  public abstract bool IsSubsetOf(IEnumerable<T> other);

  public abstract bool IsSupersetOf(IEnumerable<T> other);

  public abstract bool Overlaps(IEnumerable<T> other);
}
