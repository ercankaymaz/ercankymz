// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buCutter
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buCutter
{
  public Point3D pntEnd;
  public static byte f00392C;
  public double Radius;

  [CompilerGenerated]
  [SpecialName]
  public bool get_CamSelected() => ((Router3AXSettings) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_CamSelected(bool value) => ((Router3AXSettings) this).\u0001 = value;
}
