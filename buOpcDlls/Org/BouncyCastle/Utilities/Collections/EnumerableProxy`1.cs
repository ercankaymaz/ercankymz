// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Collections.EnumerableProxy`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Utilities.Collections;

internal sealed class EnumerableProxy<T> : IEnumerable<T>, IEnumerable
{
  private readonly IEnumerable<T> m_target;

  internal EnumerableProxy(IEnumerable<T> target)
  {
    this.m_target = target != null ? target : throw new ArgumentNullException(nameof (target));
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.m_target.GetEnumerator();

  public IEnumerator<T> GetEnumerator() => this.m_target.GetEnumerator();
}
