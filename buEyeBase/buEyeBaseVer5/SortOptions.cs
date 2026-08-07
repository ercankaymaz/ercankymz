// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortOptions
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SortOptions : buSerilization5
{
  public bool ShowInternalWires;
  public List<int> SimMovePartIndex;
  public static CollisionDetection colDetect;
  public Pnt6D pntSimOffset;
  public double Sing;
  public ViewportRefType ViewportRef;
  public ShapeGroup GroupType;
  public viewType SetView;
  public bool DrawItems;
  public bool ZoomFit;
  public List<Entity> OtherEntities;
  public Point3D calcPoint;
  public Point3D refPoint;
  public int indexSelectdOP;
  public int indexSelectdOPSub;
  public string Name;
  public List<Point3D> Points;
  public List<List<Point3D>> InnerPoints;
  public SolidItemDisplay Display;
  public Point3D StartPoint;
  public Point3D BoxMinPoint;

  public SortOptions()
  {
    ((ViewportSettings) this).Points = new List<List<Point3D>>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public SortOptions(PointsList contourpoints)
  {
    ((ViewportSettings) this).Points = new List<List<Point3D>>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    for (int index1 = 0; index1 <= ((ViewportSettings) contourpoints).Points.Count - 1; ++index1)
    {
      List<Point3D> point3DList = new List<Point3D>();
      for (int index2 = 0; index2 <= ((ViewportSettings) contourpoints).Points[index1].Count - 1; ++index2)
        point3DList.Add(new Point3D(((ViewportSettings) contourpoints).Points[index1][index2].X, ((ViewportSettings) contourpoints).Points[index1][index2].Y, ((ViewportSettings) contourpoints).Points[index1][index2].Z));
      ((ViewportSettings) this).Points.Add(point3DList);
    }
  }
}
