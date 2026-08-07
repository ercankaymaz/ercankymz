// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Collections.IStore`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Utilities.Collections;

public interface IStore<out T>
{
  IEnumerable<T> EnumerateMatches(ISelector<T> selector);
}
