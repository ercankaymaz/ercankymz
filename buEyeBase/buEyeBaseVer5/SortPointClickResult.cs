// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortPointClickResult
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SortPointClickResult : buSerilization5
{
  public string LayerName;
  public Color SolidColor;
  public Color SolidDisableColor;

  public SortPointClickResult(ContourPoints5 contourpoints)
  {
    ((FlatViewSettings) this).Outter = new List<Point3D>();
    ((FlatViewSettings) this).Inside = new List<List<Point3D>>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    for (int index = 0; index <= ((FlatViewSettings) contourpoints).Outter.Count - 1; ++index)
      ((FlatViewSettings) this).Outter.Add(new Point3D(((FlatViewSettings) contourpoints).Outter[index].X, ((FlatViewSettings) contourpoints).Outter[index].Y, ((FlatViewSettings) contourpoints).Outter[index].Z));
    for (int index1 = 0; index1 <= ((FlatViewSettings) contourpoints).Inside.Count - 1; ++index1)
    {
      List<Point3D> point3DList = new List<Point3D>();
      for (int index2 = 0; index2 <= ((FlatViewSettings) contourpoints).Inside[index1].Count - 1; ++index2)
        point3DList.Add(new Point3D(((FlatViewSettings) contourpoints).Inside[index1][index2].X, ((FlatViewSettings) contourpoints).Inside[index1][index2].Y, ((FlatViewSettings) contourpoints).Inside[index1][index2].Z));
      ((FlatViewSettings) this).Inside.Add(point3DList);
    }
  }
}
