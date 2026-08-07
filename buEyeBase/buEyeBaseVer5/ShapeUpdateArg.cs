// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ShapeUpdateArg
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ShapeUpdateArg : buSerilization5
{
  public Point3D EndPoint;
  public Point3D StopPoint;
  public Point3D ConstantPoint;
  public bool AlwaysUseZeroPointAfterJump;
  public bool If2PointAtFirstPointUseSecondOne;
  public SortingIntersectionRulesType IntersectionRules;
  public SortingNextGroupFindRulesType NextGroupRules;
  public SortingFirstCatchRulesType FirstRules;
  public bool AngleLimitation;
  public bool UseBoxBoundingForMinMax;
  public bool FindUntilToEnd;
  public double AngleMinLimit;
  public double AngleMaxLimit;
  public double FirstCatchResolution;
  public List<Point3D> ClickList;
  public Plane refPlane;
  public ToolBase5 Tool;

  public ShapeUpdateArg()
  {
    ((SortResolutionSet) this).Position = new Point3D();
    ((SortResolutionSet) this).Diameter = 10.0;
    ((SortResolutionSet) this).Depth = 4.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ShapeUpdateArg(Point3D position, double diameter, double depth)
  {
    ((SortResolutionSet) this).Position = new Point3D();
    ((SortResolutionSet) this).Diameter = 10.0;
    ((SortResolutionSet) this).Depth = 4.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((SortResolutionSet) this).Position = new Point3D(position.X, position.Y, position.Z);
    ((SortResolutionSet) this).Depth = depth;
    ((SortResolutionSet) this).Depth = depth;
    ((SortResolutionSet) this).Diameter = diameter;
  }

  public ShapeUpdateArg(DiameterDepthPoint mat)
  {
    ((SortResolutionSet) this).Position = new Point3D();
    ((SortResolutionSet) this).Diameter = 10.0;
    ((SortResolutionSet) this).Depth = 4.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) mat, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return $"Dia: {((SortResolutionSet) this).Diameter.ToString()} , Depth: {((SortResolutionSet) this).Depth.ToString()}";
  }
}
