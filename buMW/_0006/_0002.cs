// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace \u0006;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
internal class \u0002 : Attribute
{
  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern IAsyncResult BeginInvoke(int i, AsyncCallback callback, object @object);
}
