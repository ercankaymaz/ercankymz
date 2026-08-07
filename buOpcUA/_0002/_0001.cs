// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buOpcUA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF9DFBD0-0B81-4B3D-BD5F-1E30872BDC2B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcUA.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace \u0002;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
internal class \u0001 : Attribute
{
  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern string EndInvoke(IAsyncResult result);
}
