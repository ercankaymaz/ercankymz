// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PipeBendJob
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
public class PipeBendJob : buSerilization5
{
  [SpecialName]
  public int value__;
  public const \u0004.\u0001 \u0001 = ; // Unable to render the field
  public const \u0004.\u0001 \u0002 = ; // Unable to render the field
  [SpecialName]
  public int value__;
  public const \u0015.\u0001 \u0001 = ; // Unable to render the field
  public const \u0015.\u0001 \u0002 = ; // Unable to render the field
  internal IntPoint \u0001;
  internal IntPoint \u0002;
  internal IntPoint \u0003;
  internal IntPoint \u0004;

  public PipeBendJob(int InitOptions = 0)
    : this()
  {
    ((PipeBendingProgramSettings) this).\u0001 = (\u0018.\u0001) null;
    ((PipeBendTempVars) this).\u0001 = (\u0012.\u0001) null;
    ((PipeBendingProgramSettings) this).\u0001 = (\u0084.\u0001) null;
    ((PipeBendTempVars) this).\u0001 = (\u0084.\u0001) null;
    ((PipeBendTempVars) this).\u0001 = new List<IntersectNode>();
    ((PipeBendTempVars) this).\u0001 = (IComparer<IntersectNode>) new buPipeBendCalc();
    ((PipeBendTempVars) this).\u0001 = false;
    ((PipeBendTempVars) this).\u0002 = false;
    ((PipeBendingProgramSettings) this).\u0001 = new List<\u0080.\u0001>();
    ((PipeBendTempVars) this).\u0001 = new List<\u0081.\u0001>();
    ((PipeBendTempVars) this).\u0002 = new List<\u0081.\u0001>();
    this.set_ReverseSolution((1 & InitOptions) != 0);
    ((PipeBendMove) this).set_StrictlySimple((2 & InitOptions) != 0);
    ((buPipeBendCalc) this).set_PreserveCollinear((4 & InitOptions) != 0);
    ((buPipeBendCalc) this).set_ZFillFunction((buClipper.ZFillCallback) null);
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_ReverseSolution() => ((PipeBendTempVars) this).\u0003;

  [CompilerGenerated]
  [SpecialName]
  public void set_ReverseSolution(bool value) => ((PipeBendTempVars) this).\u0003 = value;
}
