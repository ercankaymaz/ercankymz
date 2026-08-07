// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Collections.ReadOnlyListProxy`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Utilities.Collections;

internal class ReadOnlyListProxy<T> : ReadOnlyList<T>
{
  private readonly IList<T> m_target;

  internal ReadOnlyListProxy(IList<T> target)
  {
    this.m_target = target != null ? target : throw new ArgumentNullException(nameof (target));
  }

  public override int Count => this.m_target.Count;

  public override bool Contains(T item) => this.m_target.Contains(item);

  public override void CopyTo(T[] array, int arrayIndex) => this.m_target.CopyTo(array, arrayIndex);

  public override IEnumerator<T> GetEnumerator() => this.m_target.GetEnumerator();

  public override int IndexOf(T item) => this.m_target.IndexOf(item);

  protected override T Lookup(int index) => this.m_target[index];
}
