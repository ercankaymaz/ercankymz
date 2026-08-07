// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Collections.StoreImpl`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Utilities.Collections;

internal sealed class StoreImpl<T> : IStore<T>
{
  private readonly List<T> m_contents;

  internal StoreImpl(IEnumerable<T> e) => this.m_contents = new List<T>(e);

  IEnumerable<T> IStore<T>.EnumerateMatches(ISelector<T> selector)
  {
    foreach (T content in this.m_contents)
    {
      if (selector == null || selector.Match(content))
        yield return content;
    }
  }
}
