// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortPointClickData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

public class SortPointClickData : buSerilization5
{
  public double SingX;
  public double SingY;
  public double SingZ;
  public double RegenDeviation;
  public double DepthOffset;
  public double StartOffset;
  public double SolidTolerance;

  public SortPointClickData()
  {
    ((FlatViewSettings) this).Outter = new List<Point3D>();
    ((FlatViewSettings) this).Inside = new List<List<Point3D>>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
