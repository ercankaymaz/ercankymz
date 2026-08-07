// Decompiled with JetBrains decompiler
// Type: buMW.MWCalculationResultEventArg
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using ModuleWorks;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace buMW;

public class MWCalculationResultEventArg
{
  public Pnt6D EndPoint;

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern IAsyncResult BeginInvoke(
    ProgressDescription rProgress,
    OverallProgressDescription rOverAllProgress,
    AsyncCallback callback,
    object @object);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void EndInvoke(IAsyncResult result);
}
