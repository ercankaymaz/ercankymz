// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ObjectSize3D
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ObjectSize3D : buSerilization5
{
  public double ExtraDepth;
  public double BoxBoundOffset;
  public double RotationStep;
  public double RotationStartAngle;
  public double RotationSweepAngle;
  public double MaxChangeDistanceFormPrevious;

  public ObjectSize3D()
  {
    ((RoboticSurfacePoint) this).Found = false;
    ((RoboticSurfacePoint) this).Enable = true;
    ((RoboticSurfacePoint) this).SnapFound = false;
    ((RoboticSurfacePoint) this).OrthoFound = false;
    ((RoboticSurfacePoint) this).OsnapFound = false;
    ((RoboticSurfacePoint) this).TrackFound = false;
    ((RoboticSurfacePoint) this).OverFound = false;
    ((RoboticSurfacePoint) this).Point = new Point3D();
    ((RoboticSurfacePoint) this).Type = osnapType.None;
    ((RoboticSurfacePoint) this).Method = osnapMethodType.None;
    ((RoboticSurfacePoint) this).UnderEntityIndex = -1;
    ((RoboticSurfacePoint) this).Width = 0.0;
    ((HitSurfacePointsSettings) this).Height = 0.0;
    ((HitSurfacePointsSettings) this).Depth = 0.0;
    ((HitSurfacePointsSettings) this).Thickness = 2.0;
    ((HitSurfacePointsCalculations) this).Color = Color.Lime;
    ((HitSurfacePointsCalculations) this).CatchBasePoints = new List<Point3D>();
    ((HitSurfacePointsCalculations) this).EntityPoint = new Point3D();
    ((AlingmentPoints3D) this).DistanceToPoint = 0.0;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public ObjectSize3D(OsnapCoordinateCatch Catch)
  {
    ((RoboticSurfacePoint) this).Found = false;
    ((RoboticSurfacePoint) this).Enable = true;
    ((RoboticSurfacePoint) this).SnapFound = false;
    ((RoboticSurfacePoint) this).OrthoFound = false;
    ((RoboticSurfacePoint) this).OsnapFound = false;
    ((RoboticSurfacePoint) this).TrackFound = false;
    ((RoboticSurfacePoint) this).OverFound = false;
    ((RoboticSurfacePoint) this).Point = new Point3D();
    ((RoboticSurfacePoint) this).Type = osnapType.None;
    ((RoboticSurfacePoint) this).Method = osnapMethodType.None;
    ((RoboticSurfacePoint) this).UnderEntityIndex = -1;
    ((RoboticSurfacePoint) this).Width = 0.0;
    ((HitSurfacePointsSettings) this).Height = 0.0;
    ((HitSurfacePointsSettings) this).Depth = 0.0;
    ((HitSurfacePointsSettings) this).Thickness = 2.0;
    ((HitSurfacePointsCalculations) this).Color = Color.Lime;
    ((HitSurfacePointsCalculations) this).CatchBasePoints = new List<Point3D>();
    ((HitSurfacePointsCalculations) this).EntityPoint = new Point3D();
    ((AlingmentPoints3D) this).DistanceToPoint = 0.0;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((RoboticSurfacePoint) this).Found = ((RoboticSurfacePoint) Catch).Found;
    ((RoboticSurfacePoint) this).SnapFound = ((RoboticSurfacePoint) Catch).SnapFound;
    ((RoboticSurfacePoint) this).OrthoFound = ((RoboticSurfacePoint) Catch).OrthoFound;
    ((RoboticSurfacePoint) this).OsnapFound = ((RoboticSurfacePoint) Catch).OsnapFound;
    ((RoboticSurfacePoint) this).TrackFound = ((RoboticSurfacePoint) Catch).TrackFound;
    ((RoboticSurfacePoint) this).OverFound = ((RoboticSurfacePoint) Catch).OverFound;
    ((RoboticSurfacePoint) this).UnderEntityIndex = ((RoboticSurfacePoint) Catch).UnderEntityIndex;
    ((RoboticSurfacePoint) this).Point = new Point3D(((RoboticSurfacePoint) Catch).Point.X, ((RoboticSurfacePoint) Catch).Point.Y, ((RoboticSurfacePoint) Catch).Point.Z);
    ((HitSurfacePointsCalculations) this).EntityPoint = new Point3D(((HitSurfacePointsCalculations) Catch).EntityPoint.X, ((HitSurfacePointsCalculations) Catch).EntityPoint.Y, ((HitSurfacePointsCalculations) Catch).EntityPoint.Z);
    ((RoboticSurfacePoint) this).Type = ((RoboticSurfacePoint) Catch).Type;
    ((RoboticSurfacePoint) this).Method = ((RoboticSurfacePoint) Catch).Method;
    ((RoboticSurfacePoint) this).Width = ((RoboticSurfacePoint) Catch).Width;
    ((HitSurfacePointsSettings) this).Height = ((HitSurfacePointsSettings) Catch).Height;
    ((HitSurfacePointsSettings) this).Depth = ((HitSurfacePointsSettings) Catch).Depth;
    ((HitSurfacePointsSettings) this).Thickness = ((HitSurfacePointsSettings) Catch).Thickness;
    ((HitSurfacePointsCalculations) this).Color = ((HitSurfacePointsCalculations) Catch).Color;
  }

  public ObjectSize3D()
  {
    ((AlingmentPoints3D) this).Type = osnapType.None;
    ((AlingmentPoints3D) this).EntName = "";
    ((AlingmentPoints3D) this).Enable = true;
    ((AlingmentPoints3D) this).LayerName = "";
    ((AlingmentPoints3D) this).OtherEntName = "";
    // ISSUE: explicit constructor call
    ((Point3D) this).\u002Ector();
    ((AlingmentPoints3D) this).Type = osnapType.None;
  }

  public ObjectSize3D(Point3D point3D, osnapType objectSnapType)
  {
    ((AlingmentPoints3D) this).Type = osnapType.None;
    ((AlingmentPoints3D) this).EntName = "";
    ((AlingmentPoints3D) this).Enable = true;
    ((AlingmentPoints3D) this).LayerName = "";
    ((AlingmentPoints3D) this).OtherEntName = "";
    // ISSUE: explicit constructor call
    ((Point3D) this).\u002Ector(point3D.X, point3D.Y, point3D.Z);
    ((AlingmentPoints3D) this).Type = objectSnapType;
  }

  public ObjectSize3D(
    Point3D point3D,
    osnapType objectSnapType,
    string entName,
    string layerName,
    string otherName)
  {
    ((AlingmentPoints3D) this).Type = osnapType.None;
    ((AlingmentPoints3D) this).EntName = "";
    ((AlingmentPoints3D) this).Enable = true;
    ((AlingmentPoints3D) this).LayerName = "";
    ((AlingmentPoints3D) this).OtherEntName = "";
    // ISSUE: explicit constructor call
    ((Point3D) this).\u002Ector(point3D.X, point3D.Y, point3D.Z);
    ((AlingmentPoints3D) this).Type = objectSnapType;
    ((AlingmentPoints3D) this).EntName = entName;
    ((AlingmentPoints3D) this).LayerName = layerName;
    ((AlingmentPoints3D) this).OtherEntName = otherName;
  }
}
