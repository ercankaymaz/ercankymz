// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.RollerJob
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
public class RollerJob : buSerilization5
{
  public bool BRotation;
  public bool CRotation;
  public bool AnglesInRadian;
  public string Tag;
  public int No;
  public int HeadNumber;
  private Transformation \u0001;
  public double xPos;
  public double yPos;
  public double zPos;
  public double aPos;

  [CompilerGenerated]
  [SpecialName]
  public void set_infoBasePoint(Point3D value) => ((Router3AXRuntimeSettings) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public entitySplineType get_CurveType() => ((Router3AXRuntimeSettings) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_CurveType(entitySplineType value)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXRuntimeSettings) this).\u0001 = value;
  }

  [CompilerGenerated]
  [SpecialName]
  public int get_Sequence() => ((Router3AXRuntimeSettings) this).\u0008;

  [CompilerGenerated]
  [SpecialName]
  public void set_Sequence(int value) => ((Router3AXRuntimeSettings) this).\u0008 = value;

  [CompilerGenerated]
  [SpecialName]
  public tuftingStitchModeType get_tuftingMode() => ((Router3AXRuntimeSettings) this).\u0001;
}
