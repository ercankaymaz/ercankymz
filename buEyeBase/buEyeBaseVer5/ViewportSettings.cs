// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ViewportSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ViewportSettings : buSerilization5
{
  public List<Point3D> TipPoints;
  public List<Point3D> BoxSizePoints;
  public List<Point3D> RotatePoints;
  public Point3D refPoint;
  public double AngleMin;
  public double AngleMax;
  public int Index;
  public static byte f00064B;
  public Point3D refPoint;
  public int Index;
  public double DomainValue;
  public static byte f00064F;
  public List<List<Point3D>> Points;
  public static byte f000651;
  public double A;
  public double B;
  public double C;
  public static byte f000655;

  public ViewportSettings()
  {
    ((AlingmentPoints3D) this).AMinLimit = -360.0;
    ((AlingmentPoints3D) this).AMaxLimit = 360.0;
    ((AlingmentPoints3D) this).BMinLimit = -360.0;
    ((PointAndAngleRange) this).BMaxLimit = 360.0;
    ((PointAndAngleRange) this).CMinLimit = -360.0;
    ((PointAndAngleRange) this).CMaxLimit = 360.0;
    ((PointAndAngleRange) this).FindMaxX = false;
    ((PointAndIndex) this).FindMaxY = false;
    ((PointAndIndex) this).FindMaxZ = true;
    ((PointAndIndex) this).TangentAngleFromNormal = -90.0;
    ((PointsList) this).isFirst = false;
    ((PointABC) this).isFirstEachSegment = false;
    ((PointABC) this).isLast = false;
    ((PointABC) this).isLastEachSegment = false;
    ((EntitiesList) this).isOutside = true;
    ((ContourPoints5) this).isInside = true;
    ((ContourPoints5) this).CheckIsClosedContour = true;
    ((BoxSize5) this).SurfaceNormalLength = 30.0;
    ((BoxSize5) this).LeadInDistance = 100.0;
    ((BoxSize5) this).SafeDistance = 80.0;
    ((BoxSize5) this).ToolOffset = 0.0;
    ((ObjectSize3D) this).ExtraDepth = 0.0;
    ((ObjectSize3D) this).BoxBoundOffset = 0.0;
    ((ObjectSize3D) this).RotationStep = 1.0;
    ((ObjectSize3D) this).RotationStartAngle = 0.0;
    ((ObjectSize3D) this).RotationSweepAngle = 360.0;
    ((ObjectSize3D) this).MaxChangeDistanceFormPrevious = 10.0;
    ((CreateModelProperties) this).FindCorrectPosMoveStep = 0.1;
    ((CreateModelProperties) this).FindCorrectPosIterationCount = 10;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ViewportSettings(MeshToSurfacePointsSettings Data)
  {
    ((AlingmentPoints3D) this).AMinLimit = -360.0;
    ((AlingmentPoints3D) this).AMaxLimit = 360.0;
    ((AlingmentPoints3D) this).BMinLimit = -360.0;
    ((PointAndAngleRange) this).BMaxLimit = 360.0;
    ((PointAndAngleRange) this).CMinLimit = -360.0;
    ((PointAndAngleRange) this).CMaxLimit = 360.0;
    ((PointAndAngleRange) this).FindMaxX = false;
    ((PointAndIndex) this).FindMaxY = false;
    ((PointAndIndex) this).FindMaxZ = true;
    ((PointAndIndex) this).TangentAngleFromNormal = -90.0;
    ((PointsList) this).isFirst = false;
    ((PointABC) this).isFirstEachSegment = false;
    ((PointABC) this).isLast = false;
    ((PointABC) this).isLastEachSegment = false;
    ((EntitiesList) this).isOutside = true;
    ((ContourPoints5) this).isInside = true;
    ((ContourPoints5) this).CheckIsClosedContour = true;
    ((BoxSize5) this).SurfaceNormalLength = 30.0;
    ((BoxSize5) this).LeadInDistance = 100.0;
    ((BoxSize5) this).SafeDistance = 80.0;
    ((BoxSize5) this).ToolOffset = 0.0;
    ((ObjectSize3D) this).ExtraDepth = 0.0;
    ((ObjectSize3D) this).BoxBoundOffset = 0.0;
    ((ObjectSize3D) this).RotationStep = 1.0;
    ((ObjectSize3D) this).RotationStartAngle = 0.0;
    ((ObjectSize3D) this).RotationSweepAngle = 360.0;
    ((ObjectSize3D) this).MaxChangeDistanceFormPrevious = 10.0;
    ((CreateModelProperties) this).FindCorrectPosMoveStep = 0.1;
    ((CreateModelProperties) this).FindCorrectPosIterationCount = 10;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) Data, ref CopiedClass);
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
}
