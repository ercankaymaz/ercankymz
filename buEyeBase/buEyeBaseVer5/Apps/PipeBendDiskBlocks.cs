// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PipeBendDiskBlocks
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buClipperLib;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class PipeBendDiskBlocks : buSerilization5
{
  internal int \u0001;
  internal IntPoint \u0001;
  internal \u0012.\u0002 \u0001;
  internal \u0012.\u0002 \u0002;
  internal \u0012.\u0002 \u0001;
  internal \u0012.\u0002 \u0002;
  internal IntPoint \u0001;
  public const long loRange = 1073741823 /*0x3FFFFFFF*/;
  public const long hiRange = 4611686018427387903 /*0x3FFFFFFFFFFFFFFF*/;
  internal \u0008.\u0001 \u0001;
  internal \u0008.\u0001 \u0002;

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void Invoke(
    IntPoint bot1,
    IntPoint top1,
    IntPoint bot2,
    IntPoint top2,
    ref IntPoint pt);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern IAsyncResult BeginInvoke(
    IntPoint bot1,
    IntPoint top1,
    IntPoint bot2,
    IntPoint top2,
    ref IntPoint pt,
    AsyncCallback callback,
    object @object);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void EndInvoke(ref IntPoint pt, IAsyncResult result);

  [CompilerGenerated]
  [SpecialName]
  public double get_ArcTolerance() => ((PipeBendTempVars) this).\u0007;

  [CompilerGenerated]
  [SpecialName]
  public void set_ArcTolerance(double value) => ((PipeBendTempVars) this).\u0007 = value;

  [CompilerGenerated]
  [SpecialName]
  public double get_MiterLimit() => ((PipeBendTempVars) this).\u0008;

  [CompilerGenerated]
  [SpecialName]
  public void set_MiterLimit(double value) => ((PipeBendTempVars) this).\u0008 = value;

  public PipeBendDiskBlocks(double miterLimit = 2.0, double arcTolerance = 0.25)
  {
    ((PipeBendTempVars) this).\u0001 = new List<DoublePoint>();
    ((PipeBendTempVars) this).\u0001 = (PolyNode) new DrawOptions();
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.set_MiterLimit(miterLimit);
    this.set_ArcTolerance(arcTolerance);
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    (^(DoorRuntimeSettings&) ref ((PipeBendTempVars) this).\u0001).X = -1L;
  }
}
