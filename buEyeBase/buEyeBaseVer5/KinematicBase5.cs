// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.KinematicBase5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class KinematicBase5 : buSerilization5
{
  public string Tags;
  public double Width;
  public double Height;
  public double Length;
  public double Angle;
  public double Radius;
  public double HeadRadius;
  public double OrientationC;
  public int Side;
  public int Degree;
  public int GroupIDIndex;
  public int CamID;
  public bool CamSelected;
  public string LayerName;
  public string Text;
  public string Data;
  public double Direction;
  public int RefIndex;
  public entitySplineType CurveType;
  public Point3D PntBase;
  public entitySortDirection sortDirection;
  public string fileName;
  public entityTypeDefination Defination;
  public static byte f000575;
  public bool AddPoint;
  public bool AddDimension;
  public bool AddCurve;
  public bool AddCircular;
  public bool AddEllipse;
  public bool AddCompositeCurve;

  public static Line2D[] Copy(Line2D[] pts)
  {
    Line2D[] line2DArray = new Line2D[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      line2DArray[index] = MachineDefPart.Copy(pts[index]);
    return line2DArray;
  }

  public static List<Line2D> Copy(List<Line2D> pts)
  {
    List<Line2D> line2DList = new List<Line2D>();
    for (int index = 0; index < pts.Count; ++index)
      line2DList.Add(MachineDefPart.Copy(pts[index]));
    return line2DList;
  }

  public static void Copy(List<Line2D> pts, ref List<Line2D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(MachineDefPart.Copy(pts[index]));
  }

  public override string ToString()
  {
    return $"{((EntityDataSet) this).StartPoint.ToString()} -  {((EntitiesCopySettings) this).EndPoint.ToString()}";
  }

  public abstract void m00021F();

  public KinematicBase5()
  {
    ((EntitiesCopySettings) this).Char = "";
    ((EntitiesCopySettings) this).Index = 0;
    ((EntitiesCopySettings) this).CharEntities = new List<buEntity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public KinematicBase5(string chars)
  {
    ((EntitiesCopySettings) this).Char = "";
    ((EntitiesCopySettings) this).Index = 0;
    ((EntitiesCopySettings) this).CharEntities = new List<buEntity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((EntitiesCopySettings) this).Char = chars;
  }
}
