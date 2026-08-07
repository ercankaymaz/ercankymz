// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortbuSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SortbuSettings : buSerilization5
{
  public Color WireColor;
  public List<buEntity> entitiesCurve;
  public List<EntitiesList> entitiesCurveList;
  public List<Entity> entitiesEngraving;

  public SortbuSettings(List<Point3D> outter, List<List<Point3D>> inside)
  {
    ((FlatViewSettings) this).Outter = new List<Point3D>();
    ((FlatViewSettings) this).Inside = new List<List<Point3D>>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    for (int index = 0; index <= outter.Count - 1; ++index)
      ((FlatViewSettings) this).Outter.Add(new Point3D(outter[index].X, outter[index].Y, outter[index].Z));
    for (int index1 = 0; index1 <= inside.Count - 1; ++index1)
    {
      List<Point3D> point3DList = new List<Point3D>();
      for (int index2 = 0; index2 <= inside[index1].Count - 1; ++index2)
        point3DList.Add(new Point3D(inside[index1][index2].X, inside[index1][index2].Y, inside[index1][index2].Z));
      ((FlatViewSettings) this).Inside.Add(point3DList);
    }
  }

  public SortbuSettings(List<Point3D> outter)
  {
    ((FlatViewSettings) this).Outter = new List<Point3D>();
    ((FlatViewSettings) this).Inside = new List<List<Point3D>>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    for (int index = 0; index <= outter.Count - 1; ++index)
      ((FlatViewSettings) this).Outter.Add(new Point3D(outter[index].X, outter[index].Y, outter[index].Z));
    ((FlatViewSettings) this).Inside = new List<List<Point3D>>();
  }
}
