// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortResult
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SortResult : buSerilization5
{
  public Point3D Sing;
  public Image matImage;
  public SizeObject Size;
  public double FrontAngle;
  public double BackAngle;
  public double LeftAngle;
  public double RightAngle;

  public SortResult()
  {
    ((ViewportSettings) this).A = 0.0;
    ((ViewportSettings) this).B = 0.0;
    ((ViewportSettings) this).C = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
