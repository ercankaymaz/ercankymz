// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PipeBendMove
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
public class PipeBendMove : buSerilization5
{
  internal double \u0001;
  internal PolyType \u0001;
  internal \u0004.\u0001 \u0001;
  internal int \u0001;
  internal int \u0002;
  internal int \u0003;
  internal int \u0004;

  [CompilerGenerated]
  [SpecialName]
  public bool get_StrictlySimple() => ((PipeBendTempVars) this).\u0004;

  [CompilerGenerated]
  [SpecialName]
  public void set_StrictlySimple(bool value) => ((PipeBendTempVars) this).\u0004 = value;

  public bool Execute(ClipType clipType, List<List<IntPoint>> solution, PolyFillType FillType = ); // Unable to render the method

  public bool Execute(ClipType clipType, PolyTree polytree, PolyFillType FillType = ); // Unable to render the method

  public bool Execute(
    ClipType clipType,
    List<List<IntPoint>> solution,
    PolyFillType subjFillType,
    PolyFillType clipFillType)
  {
    // ISSUE: unable to decompile the method.
  }

  public bool Execute(
    ClipType clipType,
    PolyTree polytree,
    PolyFillType subjFillType,
    PolyFillType clipFillType)
  {
    // ISSUE: unable to decompile the method.
  }
}
