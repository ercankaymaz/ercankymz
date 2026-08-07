// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ToolGrindingRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ToolGrindingRuntimeSettings : buSerilization5
{
  public Point3D centerPointOfA;
  public Point3D centerPointOfB;

  [CompilerGenerated]
  [SpecialName]
  public double get_infoHeadRadius() => ((Router3AXRuntimeSettings) this).\u0011;

  [CompilerGenerated]
  [SpecialName]
  public void set_infoHeadRadius(double value) => ((Router3AXRuntimeSettings) this).\u0011 = value;
}
