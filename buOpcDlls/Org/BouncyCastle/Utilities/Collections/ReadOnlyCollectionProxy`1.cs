// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Collections.ReadOnlyCollectionProxy`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Utilities.Collections;

internal class ReadOnlyCollectionProxy<T> : ReadOnlyCollection<T>
{
  private readonly ICollection<T> m_target;

  internal ReadOnlyCollectionProxy(ICollection<T> target)
  {
    this.m_target = target != null ? target : throw new ArgumentNullException(nameof (target));
  }

  public override bool Contains(T item) => this.m_target.Contains(item);

  public override int Count => this.m_target.Count;

  public override void CopyTo(T[] array, int arrayIndex) => this.m_target.CopyTo(array, arrayIndex);

  public override IEnumerator<T> GetEnumerator() => this.m_target.GetEnumerator();
}
