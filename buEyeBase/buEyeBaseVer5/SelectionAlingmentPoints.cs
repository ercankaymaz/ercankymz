// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SelectionAlingmentPoints
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SelectionAlingmentPoints : buSerilization5
{
  public int HoleCount;
  public double HoleStartDistance;
  public double HoleEndDistance;
  public double HoleAngle;

  public SelectionAlingmentPoints()
  {
    ((SortbuMostClosedResult) this).isPointOnEntity = false;
    ((SortbuMostClosedResult) this).SelectedIndex = 0;
    ((ShapeEdit) this).PreviousSelectedIndex = -1;
    ((ShapeEdit) this).FoundCount = 0;
    ((ShapeEdit) this).CatchPoint = (Point3D) null;
    ((ShapeEdit) this).PreCatchPoint = (Point3D) null;
    ((ShapeEdit) this).IntersectionPoint = (Point3D) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public SelectionAlingmentPoints()
  {
    ((ShapeArray) this).FirstPoint = new Point3D();
    ((ShapeArray) this).LastPoint = new Point3D();
    ((ShapeArray) this).ResultType = SortingResultType.None;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
