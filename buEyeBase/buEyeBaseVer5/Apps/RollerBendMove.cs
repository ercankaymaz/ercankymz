// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.RollerBendMove
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class RollerBendMove : buSerilization5
{
  public double bPos;
  public double cPos;
  public double xRot;
  public double yRot;
  public double zRot;
  public double aPos2;
  public double bPos2;
  public double cPos2;
  public Point3D centerPointOfA;
  public Point3D centerPointOfB;

  [CompilerGenerated]
  [SpecialName]
  public void set_tuftingMode(tuftingStitchModeType value)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXRuntimeSettings) this).\u0001 = value;
  }

  [CompilerGenerated]
  [SpecialName]
  public double get_tuftingPileHeight() => ((Router3AXTempVars) this).\u0012;

  [CompilerGenerated]
  [SpecialName]
  public void set_tuftingPileHeight(double value) => ((Router3AXTempVars) this).\u0012 = value;

  [CompilerGenerated]
  [SpecialName]
  public double get_tuftingStitchLength() => ((Router3AXTempVars) this).\u0013;

  [CompilerGenerated]
  [SpecialName]
  public void set_tuftingStitchLength(double value) => ((Router3AXTempVars) this).\u0013 = value;
}
