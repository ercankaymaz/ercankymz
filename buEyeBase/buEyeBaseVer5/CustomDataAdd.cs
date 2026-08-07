// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.CustomDataAdd
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class CustomDataAdd : buSerilization5
{
  public double CutAngle;
  public double ProfilingRadius;
  public double ProfilingLength;
  public double ProfilingWidth;
  public double ProfilingHeight;
  public double ProfilingDepth;
  public double EngravingWidth;
  public double EngravingHeight;
  public double EngravingDepth;
  public double EngravingOffsetZ;
  public double JunctionDiameter;
  public double JunctionDiameterOutside;
  public double JunctionDistance;
  public double JunctionDepth;
  public double NotchWidth;
  public double NotchHeight;

  public CustomDataAdd(SortbuFilter data)
  {
    ((ShapeArray) this).NotSelectEntities = new List<buEntity>();
    ((ShapeMirror) this).SelectableEntities = new List<buEntity>();
    ((ShapeMirror) this).NotSelectIndex = new List<int>();
    ((ShapeMirror) this).SelectableIndex = new List<int>();
    ((ShapeMirror) this).NotSelectColor = new List<Color>();
    ((ShapeMirror) this).SelectableColor = new List<Color>();
    ((ShapeSizeInfo) this).MostClosestType = MostClosestPointType.OnlyNotCamSelectedEntities;
    ((ShapeSizeInfo) this).UsePointEntities = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    ((ShapeMirror) this).NotSelectColor = new List<Color>();
    for (int index = 0; index <= ((ShapeMirror) data).NotSelectColor.Count - 1; ++index)
      ((ShapeMirror) this).NotSelectColor.Add(((ShapeMirror) data).NotSelectColor[index]);
    ((ShapeMirror) this).SelectableColor = new List<Color>();
    for (int index = 0; index <= ((ShapeMirror) data).SelectableColor.Count - 1; ++index)
      ((ShapeMirror) this).SelectableColor.Add(((ShapeMirror) data).SelectableColor[index]);
    ((ShapeMirror) this).NotSelectIndex = new List<int>();
    for (int index = 0; index <= ((ShapeMirror) data).NotSelectIndex.Count - 1; ++index)
      ((ShapeMirror) this).NotSelectIndex.Add(((ShapeMirror) data).NotSelectIndex[index]);
    ((ShapeMirror) this).SelectableIndex = new List<int>();
    for (int index = 0; index <= ((ShapeMirror) data).SelectableIndex.Count - 1; ++index)
      ((ShapeMirror) this).SelectableIndex.Add(((ShapeMirror) data).SelectableIndex[index]);
    ((ShapeArray) this).NotSelectEntities = new List<buEntity>();
    buRadialDim.Copy(((ShapeArray) data).NotSelectEntities, ref ((ShapeArray) this).NotSelectEntities);
    ((ShapeMirror) this).SelectableEntities = new List<buEntity>();
    buRadialDim.Copy(((ShapeMirror) data).SelectableEntities, ref ((ShapeMirror) this).SelectableEntities);
  }

  public CustomDataAdd()
  {
    ((ShapeSizeInfo) this).Resolution = 0.02;
    ((ShapeLeadInOut) this).UsePlane = false;
    ((ShapeLeadInOut) this).UseCamSelectedProps = false;
    ((ShapeLeadInOut) this).IgnoreCamSelected = false;
    ((ShapeLeadInOut) this).UseEntitySelectedProps = false;
    ((ShapeMultiCenterData) this).isFirstPointCatchFromStartPointForDrawSequence = false;
    ((ShapeMultiCenterData) this).PreferLineIfAvailableForFirstTouch = false;
    ((ShapeProfileData) this).WhenFoundClosedCurveThenFinish = false;
    ((ShapeProfileData) this).Jump = false;
    ((ShapeProfileData) this).StartPoint = new Point3D();
    ((ShapeUpdateArg) this).EndPoint = new Point3D();
    ((ShapeUpdateArg) this).StopPoint = (Point3D) null;
    ((ShapeUpdateArg) this).ConstantPoint = new Point3D();
    ((ShapeUpdateArg) this).AlwaysUseZeroPointAfterJump = false;
    ((ShapeUpdateArg) this).If2PointAtFirstPointUseSecondOne = false;
    ((ShapeUpdateArg) this).IntersectionRules = SortingIntersectionRulesType.LowerIndex;
    ((ShapeUpdateArg) this).NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
    ((ShapeUpdateArg) this).FirstRules = SortingFirstCatchRulesType.LowerIndex;
    ((ShapeUpdateArg) this).AngleLimitation = false;
    ((ShapeUpdateArg) this).UseBoxBoundingForMinMax = false;
    ((ShapeUpdateArg) this).FindUntilToEnd = false;
    ((ShapeUpdateArg) this).AngleMinLimit = -360.0;
    ((ShapeUpdateArg) this).AngleMaxLimit = 360.0;
    ((ShapeUpdateArg) this).FirstCatchResolution = 0.0;
    ((ShapeUpdateArg) this).ClickList = new List<Point3D>();
    ((ShapeUpdateArg) this).refPlane = new Plane();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public CustomDataAdd(SortbuOptions data)
  {
    ((ShapeSizeInfo) this).Resolution = 0.02;
    ((ShapeLeadInOut) this).UsePlane = false;
    ((ShapeLeadInOut) this).UseCamSelectedProps = false;
    ((ShapeLeadInOut) this).IgnoreCamSelected = false;
    ((ShapeLeadInOut) this).UseEntitySelectedProps = false;
    ((ShapeMultiCenterData) this).isFirstPointCatchFromStartPointForDrawSequence = false;
    ((ShapeMultiCenterData) this).PreferLineIfAvailableForFirstTouch = false;
    ((ShapeProfileData) this).WhenFoundClosedCurveThenFinish = false;
    ((ShapeProfileData) this).Jump = false;
    ((ShapeProfileData) this).StartPoint = new Point3D();
    ((ShapeUpdateArg) this).EndPoint = new Point3D();
    ((ShapeUpdateArg) this).StopPoint = (Point3D) null;
    ((ShapeUpdateArg) this).ConstantPoint = new Point3D();
    ((ShapeUpdateArg) this).AlwaysUseZeroPointAfterJump = false;
    ((ShapeUpdateArg) this).If2PointAtFirstPointUseSecondOne = false;
    ((ShapeUpdateArg) this).IntersectionRules = SortingIntersectionRulesType.LowerIndex;
    ((ShapeUpdateArg) this).NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
    ((ShapeUpdateArg) this).FirstRules = SortingFirstCatchRulesType.LowerIndex;
    ((ShapeUpdateArg) this).AngleLimitation = false;
    ((ShapeUpdateArg) this).UseBoxBoundingForMinMax = false;
    ((ShapeUpdateArg) this).FindUntilToEnd = false;
    ((ShapeUpdateArg) this).AngleMinLimit = -360.0;
    ((ShapeUpdateArg) this).AngleMaxLimit = 360.0;
    ((ShapeUpdateArg) this).FirstCatchResolution = 0.0;
    ((ShapeUpdateArg) this).ClickList = new List<Point3D>();
    ((ShapeUpdateArg) this).refPlane = new Plane();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    if (((ShapeProfileData) data).StartPoint != (Point3D) null)
      ((ShapeProfileData) this).StartPoint = new Point3D(((ShapeProfileData) data).StartPoint.X, ((ShapeProfileData) data).StartPoint.Y, ((ShapeProfileData) data).StartPoint.Z);
    if (((ShapeUpdateArg) data).EndPoint != (Point3D) null)
      ((ShapeUpdateArg) this).EndPoint = new Point3D(((ShapeUpdateArg) data).EndPoint.X, ((ShapeUpdateArg) data).EndPoint.Y, ((ShapeUpdateArg) data).EndPoint.Z);
    if (((ShapeUpdateArg) data).StopPoint != (Point3D) null)
      ((ShapeUpdateArg) this).StopPoint = new Point3D(((ShapeUpdateArg) data).StopPoint.X, ((ShapeUpdateArg) data).StopPoint.Y, ((ShapeUpdateArg) data).StopPoint.Z);
    if (((ShapeUpdateArg) data).ConstantPoint != (Point3D) null)
      ((ShapeUpdateArg) this).ConstantPoint = new Point3D(((ShapeUpdateArg) data).ConstantPoint.X, ((ShapeUpdateArg) data).ConstantPoint.Y, ((ShapeUpdateArg) data).ConstantPoint.Z);
    ((ShapeUpdateArg) this).refPlane = (Plane) ((ShapeUpdateArg) data).refPlane.Clone();
    ((ShapeUpdateArg) this).ClickList = new List<Point3D>();
    for (int index = 0; index <= ((ShapeUpdateArg) data).ClickList.Count - 1; ++index)
      ((ShapeUpdateArg) this).ClickList.Add(new Point3D(((ShapeUpdateArg) data).ClickList[index].X, ((ShapeUpdateArg) data).ClickList[index].Y, ((ShapeUpdateArg) data).ClickList[index].Z));
  }

  public CustomDataAdd()
  {
    ((ShapeUpdateArg) this).Tool = (ToolBase5) new ToolGeometry5();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
