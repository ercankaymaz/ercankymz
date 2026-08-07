// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buRollerBendCalc
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buRollerBendCalc
{
  public Point3D centerPointOfC;
  public bool ARotation;

  [CompilerGenerated]
  [SpecialName]
  public int get_infoDegree() => ((Router3AXRuntimeSettings) this).\u0007;

  [CompilerGenerated]
  [SpecialName]
  public void set_infoDegree(int value) => ((Router3AXRuntimeSettings) this).\u0007 = value;

  [CompilerGenerated]
  [SpecialName]
  public Point3D get_infoBasePoint() => ((Router3AXRuntimeSettings) this).\u0001;
}
