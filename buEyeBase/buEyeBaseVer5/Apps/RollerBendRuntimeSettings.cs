// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.RollerBendRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class RollerBendRuntimeSettings : buSerilization5
{
  public Point3D centerPointOfC;
  public Point3D centerPointOfA2;
  public Point3D centerPointOfB2;
  public Point3D centerPointOfC2;
  public Vector3D vectorARotation;
  public Vector3D vectorBRotation;
  public Vector3D vectorCRotation;
  public Vector3D vectorARotation2;
  public Vector3D vectorBRotation2;
  public Vector3D vectorCRotation2;

  [CompilerGenerated]
  [SpecialName]
  public string get_ID() => ((Router3AXTempVars) this).\u0007;

  [CompilerGenerated]
  [SpecialName]
  public void set_ID(string value) => ((Router3AXTempVars) this).\u0007 = value;
}
