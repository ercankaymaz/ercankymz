// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Collections.ReadOnlySetProxy`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Utilities.Collections;

internal class ReadOnlySetProxy<T> : ReadOnlySet<T>
{
  private readonly ISet<T> m_target;

  internal ReadOnlySetProxy(ISet<T> target)
  {
    this.m_target = target != null ? target : throw new ArgumentNullException(nameof (target));
  }

  public override bool Contains(T item) => this.m_target.Contains(item);

  public override void CopyTo(T[] array, int arrayIndex) => this.m_target.CopyTo(array, arrayIndex);

  public override int Count => this.m_target.Count;

  public override IEnumerator<T> GetEnumerator() => this.m_target.GetEnumerator();

  public override bool IsProperSubsetOf(IEnumerable<T> other)
  {
    return this.m_target.IsProperSubsetOf(other);
  }

  public override bool IsProperSupersetOf(IEnumerable<T> other)
  {
    return this.m_target.IsProperSupersetOf(other);
  }

  public override bool IsSubsetOf(IEnumerable<T> other) => this.m_target.IsSubsetOf(other);

  public override bool IsSupersetOf(IEnumerable<T> other) => this.m_target.IsSupersetOf(other);

  public override bool Overlaps(IEnumerable<T> other) => this.m_target.Overlaps(other);
}
