// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buPowerNest, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: EB8978B5-B2D2-48FE-B448-717DFAAD425B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buPowerNest.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace \u0001;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
internal sealed class \u0001 : Attribute
{
  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern string EndInvoke(IAsyncResult result);
}
