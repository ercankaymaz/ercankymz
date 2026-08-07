// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingResultSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingResultSettings : buSerilization5
{
  public Color CornerArrowYColor;
  public Color CornerArrowZColor;
  public Color CornerArrowBallColor;
  public double NewSheetWidth;
  public double NewSheetLength;
  public double NewSheetHeight;
  public ClockDirectionType RotateClockType;
  public double RotateDegree;
  public MirrorBoxType MirrorType;
  public bool MirrorCopyAsNew;
  public planeBoxNames lastDrillPlaneNames;
  public planeBoxNames lastContourPlaneNames;
  public planeBoxNames lastShapePlaneNames;
  public planeBoxNames lastProfilingPlaneNames;
  public planeBoxNames lastTextPlaneNames;
  public CornerLocation Corner;
  public Point3D drillPoint;
  public double drillDepth;

  public int NearestZPoint(DrillCalcItem srcPt, List<DrillCalcItem> lookIn)
  {
    KeyValuePair<double, int> keyValuePair = new KeyValuePair<double, int>();
    for (int index = 0; index < lookIn.Count; ++index)
    {
      double key = ((DrillRuntimeSettings) srcPt).Center.Z - ((DrillRuntimeSettings) lookIn[index]).Center.Z;
      if (index == 0)
        keyValuePair = new KeyValuePair<double, int>(key, index);
      else if (key < keyValuePair.Key)
        keyValuePair = new KeyValuePair<double, int>(key, index);
    }
    return keyValuePair.Value;
  }

  public void CoordinateFromPlaneAndCorner(
    SizeObject Size,
    CornerLocation Corner,
    planeBoxNames Plane,
    ref DrillItemBase Item,
    Point3D refPoint,
    double Sing)
  {
    ((DrillRuntimeSettings) Item).Corner = Corner;
    if (Sing == -1.0)
    {
      if (Plane == planeBoxNames.Top)
      {
        if (Corner == CornerLocation.LeftBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, Size.Depth);
          ((DrillRuntimeSettings) Item).BaseCenter.X = Size.Width - refPoint.X;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = Size.Height - refPoint.Y;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = Size.Depth;
        }
        if (Corner == CornerLocation.LeftTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, 0.0, Size.Depth);
          ((DrillRuntimeSettings) Item).BaseCenter.X = Size.Width - refPoint.X;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = refPoint.Y;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = Size.Depth;
        }
        if (Corner == CornerLocation.RightBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, Sing * Size.Height, Size.Depth);
          ((DrillRuntimeSettings) Item).BaseCenter.X = refPoint.X;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = Size.Height - refPoint.Y;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = Size.Depth;
        }
        if (Corner == CornerLocation.RightTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, 0.0, Size.Depth);
          ((DrillRuntimeSettings) Item).BaseCenter.X = refPoint.X;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = refPoint.Y;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = Size.Depth;
        }
      }
      if (Plane == planeBoxNames.Bottom)
      {
        if (Corner == CornerLocation.LeftBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, 0.0);
          ((DrillRuntimeSettings) Item).BaseCenter.X = Size.Width - refPoint.X;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = Size.Height - refPoint.Y;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = Size.Depth;
        }
        if (Corner == CornerLocation.LeftTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, 0.0, 0.0);
          ((DrillRuntimeSettings) Item).BaseCenter.X = Size.Width - refPoint.X;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = refPoint.Y;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = Size.Depth;
        }
        if (Corner == CornerLocation.RightBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, Sing * Size.Height, 0.0);
          ((DrillRuntimeSettings) Item).BaseCenter.X = refPoint.X;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = Size.Height - refPoint.Y;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = Size.Depth;
        }
        if (Corner == CornerLocation.RightTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, 0.0, 0.0);
          ((DrillRuntimeSettings) Item).BaseCenter.X = refPoint.X;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = refPoint.Y;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = Size.Depth;
        }
      }
      if (Plane == planeBoxNames.Front)
      {
        if (Corner == CornerLocation.LeftBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, Sing * Size.Height, 0.0);
          ((DrillRuntimeSettings) Item).BaseCenter.X = 0.0;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = Size.Height - refPoint.Y;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = refPoint.Z;
        }
        if (Corner == CornerLocation.LeftTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, Sing * Size.Height, Size.Depth);
          ((DrillRuntimeSettings) Item).BaseCenter.X = 0.0;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = Size.Height - refPoint.Y;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = Size.Depth - refPoint.Z;
        }
        if (Corner == CornerLocation.RightBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, 0.0, 0.0);
          ((DrillRuntimeSettings) Item).BaseCenter.X = 0.0;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = refPoint.Y;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = refPoint.Z;
        }
        if (Corner == CornerLocation.RightTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, 0.0, Size.Depth);
          ((DrillRuntimeSettings) Item).BaseCenter.X = 0.0;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = refPoint.Y;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = Size.Depth - refPoint.Z;
        }
      }
      if (Plane == planeBoxNames.Back)
      {
        if (Corner == CornerLocation.LeftBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, 0.0);
          ((DrillRuntimeSettings) Item).BaseCenter.X = Size.Width;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = Size.Height - refPoint.Y;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = refPoint.Z;
        }
        if (Corner == CornerLocation.LeftTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, Size.Depth);
          ((DrillRuntimeSettings) Item).BaseCenter.X = Size.Width;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = Size.Height - refPoint.Y;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = Size.Depth - refPoint.Z;
        }
        if (Corner == CornerLocation.RightBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, 0.0, 0.0);
          ((DrillRuntimeSettings) Item).BaseCenter.X = Size.Width;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = refPoint.Y;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = refPoint.Z;
        }
        if (Corner == CornerLocation.RightTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, 0.0, Size.Depth);
          ((DrillRuntimeSettings) Item).BaseCenter.X = Size.Width;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = refPoint.Y;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = Size.Depth - refPoint.Z;
        }
      }
      if (Plane == planeBoxNames.Right)
      {
        if (Corner == CornerLocation.LeftBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, 0.0);
          ((DrillRuntimeSettings) Item).BaseCenter.X = Size.Width - refPoint.X;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = Size.Height;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = refPoint.Z;
        }
        if (Corner == CornerLocation.LeftTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, Size.Depth);
          ((DrillRuntimeSettings) Item).BaseCenter.X = Size.Width - refPoint.X;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = Size.Height;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = Size.Depth - refPoint.Z;
        }
        if (Corner == CornerLocation.RightBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, Sing * Size.Height, 0.0);
          ((DrillRuntimeSettings) Item).BaseCenter.X = refPoint.X;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = Size.Height;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = refPoint.Z;
        }
        if (Corner == CornerLocation.RightTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, Sing * Size.Height, Size.Depth);
          ((DrillRuntimeSettings) Item).BaseCenter.X = refPoint.X;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = Size.Height;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = Size.Depth - refPoint.Z;
        }
      }
      if (Plane == planeBoxNames.Left)
      {
        if (Corner == CornerLocation.LeftBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, 0.0, 0.0);
          ((DrillRuntimeSettings) Item).BaseCenter.X = Size.Width - refPoint.X;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = 0.0;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = refPoint.Z;
        }
        if (Corner == CornerLocation.LeftTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, 0.0, Size.Depth);
          ((DrillRuntimeSettings) Item).BaseCenter.X = Size.Width - refPoint.X;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = 0.0;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = Size.Depth - refPoint.Z;
        }
        if (Corner == CornerLocation.RightBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, 0.0, 0.0);
          ((DrillRuntimeSettings) Item).BaseCenter.X = refPoint.X;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = 0.0;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = refPoint.Z;
        }
        if (Corner == CornerLocation.RightTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, 0.0, Size.Depth);
          ((DrillRuntimeSettings) Item).BaseCenter.X = refPoint.X;
          ((DrillRuntimeSettings) Item).BaseCenter.Y = 0.0;
          ((DrillRuntimeSettings) Item).BaseCenter.Z = Size.Depth - refPoint.Z;
        }
      }
    }
    ((buNestingDraw) this).GetDirectionVectorFromCornerAndPlane(ref Item);
  }

  public void CoordinateFromPlaneAndCorner(
    SizeObject Size,
    CornerLocation Corner,
    planeBoxNames Plane,
    ref DrillItem Item,
    Point3D refPoint,
    double Sing)
  {
    ((DrillRuntimeSettings) Item).Corner = Corner;
    if (Sing == -1.0)
    {
      if (Plane == planeBoxNames.Top)
      {
        if (Corner == CornerLocation.LeftBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, Size.Depth);
          ((DrillRuntimeSettings) Item).Center.X = Size.Width - refPoint.X;
          ((DrillRuntimeSettings) Item).Center.Y = Size.Height - refPoint.Y;
          ((DrillRuntimeSettings) Item).Center.Z = Size.Depth;
        }
        if (Corner == CornerLocation.LeftTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, 0.0, Size.Depth);
          ((DrillRuntimeSettings) Item).Center.X = Size.Width - refPoint.X;
          ((DrillRuntimeSettings) Item).Center.Y = refPoint.Y;
          ((DrillRuntimeSettings) Item).Center.Z = Size.Depth;
        }
        if (Corner == CornerLocation.RightBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, Sing * Size.Height, Size.Depth);
          ((DrillRuntimeSettings) Item).Center.X = refPoint.X;
          ((DrillRuntimeSettings) Item).Center.Y = Size.Height - refPoint.Y;
          ((DrillRuntimeSettings) Item).Center.Z = Size.Depth;
        }
        if (Corner == CornerLocation.RightTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, 0.0, Size.Depth);
          ((DrillRuntimeSettings) Item).Center.X = refPoint.X;
          ((DrillRuntimeSettings) Item).Center.Y = refPoint.Y;
          ((DrillRuntimeSettings) Item).Center.Z = Size.Depth;
        }
      }
      if (Plane == planeBoxNames.Bottom)
      {
        if (Corner == CornerLocation.LeftBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, 0.0);
          ((DrillRuntimeSettings) Item).Center.X = Size.Width - refPoint.X;
          ((DrillRuntimeSettings) Item).Center.Y = Size.Height - refPoint.Y;
          ((DrillRuntimeSettings) Item).Center.Z = Size.Depth;
        }
        if (Corner == CornerLocation.LeftTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, 0.0, 0.0);
          ((DrillRuntimeSettings) Item).Center.X = Size.Width - refPoint.X;
          ((DrillRuntimeSettings) Item).Center.Y = refPoint.Y;
          ((DrillRuntimeSettings) Item).Center.Z = Size.Depth;
        }
        if (Corner == CornerLocation.RightBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, Sing * Size.Height, 0.0);
          ((DrillRuntimeSettings) Item).Center.X = refPoint.X;
          ((DrillRuntimeSettings) Item).Center.Y = Size.Height - refPoint.Y;
          ((DrillRuntimeSettings) Item).Center.Z = Size.Depth;
        }
        if (Corner == CornerLocation.RightTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, 0.0, 0.0);
          ((DrillRuntimeSettings) Item).Center.X = refPoint.X;
          ((DrillRuntimeSettings) Item).Center.Y = refPoint.Y;
          ((DrillRuntimeSettings) Item).Center.Z = Size.Depth;
        }
      }
      if (Plane == planeBoxNames.Front)
      {
        if (Corner == CornerLocation.LeftBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, Sing * Size.Height, 0.0);
          ((DrillRuntimeSettings) Item).Center.X = 0.0;
          ((DrillRuntimeSettings) Item).Center.Y = Size.Height - refPoint.Y;
          ((DrillRuntimeSettings) Item).Center.Z = refPoint.Z;
        }
        if (Corner == CornerLocation.LeftTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, Sing * Size.Height, Size.Depth);
          ((DrillRuntimeSettings) Item).Center.X = 0.0;
          ((DrillRuntimeSettings) Item).Center.Y = Size.Height - refPoint.Y;
          ((DrillRuntimeSettings) Item).Center.Z = Size.Depth - refPoint.Z;
        }
        if (Corner == CornerLocation.RightBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, 0.0, 0.0);
          ((DrillRuntimeSettings) Item).Center.X = 0.0;
          ((DrillRuntimeSettings) Item).Center.Y = refPoint.Y;
          ((DrillRuntimeSettings) Item).Center.Z = refPoint.Z;
        }
        if (Corner == CornerLocation.RightTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, 0.0, Size.Depth);
          ((DrillRuntimeSettings) Item).Center.X = 0.0;
          ((DrillRuntimeSettings) Item).Center.Y = refPoint.Y;
          ((DrillRuntimeSettings) Item).Center.Z = Size.Depth - refPoint.Z;
        }
      }
      if (Plane == planeBoxNames.Back)
      {
        if (Corner == CornerLocation.LeftBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, 0.0);
          ((DrillRuntimeSettings) Item).Center.X = Size.Width;
          ((DrillRuntimeSettings) Item).Center.Y = Size.Height - refPoint.Y;
          ((DrillRuntimeSettings) Item).Center.Z = refPoint.Z;
        }
        if (Corner == CornerLocation.LeftTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, Size.Depth);
          ((DrillRuntimeSettings) Item).Center.X = Size.Width;
          ((DrillRuntimeSettings) Item).Center.Y = Size.Height - refPoint.Y;
          ((DrillRuntimeSettings) Item).Center.Z = Size.Depth - refPoint.Z;
        }
        if (Corner == CornerLocation.RightBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, 0.0, 0.0);
          ((DrillRuntimeSettings) Item).Center.X = Size.Width;
          ((DrillRuntimeSettings) Item).Center.Y = refPoint.Y;
          ((DrillRuntimeSettings) Item).Center.Z = refPoint.Z;
        }
        if (Corner == CornerLocation.RightTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, 0.0, Size.Depth);
          ((DrillRuntimeSettings) Item).Center.X = Size.Width;
          ((DrillRuntimeSettings) Item).Center.Y = refPoint.Y;
          ((DrillRuntimeSettings) Item).Center.Z = Size.Depth - refPoint.Z;
        }
      }
      if (Plane == planeBoxNames.Right)
      {
        if (Corner == CornerLocation.LeftBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, 0.0);
          ((DrillRuntimeSettings) Item).Center.X = Size.Width - refPoint.X;
          ((DrillRuntimeSettings) Item).Center.Y = Size.Height;
          ((DrillRuntimeSettings) Item).Center.Z = refPoint.Z;
        }
        if (Corner == CornerLocation.LeftTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, Size.Depth);
          ((DrillRuntimeSettings) Item).Center.X = Size.Width - refPoint.X;
          ((DrillRuntimeSettings) Item).Center.Y = Size.Height;
          ((DrillRuntimeSettings) Item).Center.Z = Size.Depth - refPoint.Z;
        }
        if (Corner == CornerLocation.RightBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, Sing * Size.Height, 0.0);
          ((DrillRuntimeSettings) Item).Center.X = refPoint.X;
          ((DrillRuntimeSettings) Item).Center.Y = Size.Height;
          ((DrillRuntimeSettings) Item).Center.Z = refPoint.Z;
        }
        if (Corner == CornerLocation.RightTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, Sing * Size.Height, Size.Depth);
          ((DrillRuntimeSettings) Item).Center.X = refPoint.X;
          ((DrillRuntimeSettings) Item).Center.Y = Size.Height;
          ((DrillRuntimeSettings) Item).Center.Z = Size.Depth - refPoint.Z;
        }
      }
      if (Plane == planeBoxNames.Left)
      {
        if (Corner == CornerLocation.LeftBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, 0.0, 0.0);
          ((DrillRuntimeSettings) Item).Center.X = Size.Width - refPoint.X;
          ((DrillRuntimeSettings) Item).Center.Y = 0.0;
          ((DrillRuntimeSettings) Item).Center.Z = refPoint.Z;
        }
        if (Corner == CornerLocation.LeftTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(Sing * Size.Width, 0.0, Size.Depth);
          ((DrillRuntimeSettings) Item).Center.X = Size.Width - refPoint.X;
          ((DrillRuntimeSettings) Item).Center.Y = 0.0;
          ((DrillRuntimeSettings) Item).Center.Z = Size.Depth - refPoint.Z;
        }
        if (Corner == CornerLocation.RightBottom)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, 0.0, 0.0);
          ((DrillRuntimeSettings) Item).Center.X = refPoint.X;
          ((DrillRuntimeSettings) Item).Center.Y = 0.0;
          ((DrillRuntimeSettings) Item).Center.Z = refPoint.Z;
        }
        if (Corner == CornerLocation.RightTop)
        {
          ((DrillRuntimeSettings) Item).CornerPoint = new Point3D(0.0, 0.0, Size.Depth);
          ((DrillRuntimeSettings) Item).Center.X = refPoint.X;
          ((DrillRuntimeSettings) Item).Center.Y = 0.0;
          ((DrillRuntimeSettings) Item).Center.Z = Size.Depth - refPoint.Z;
        }
      }
    }
    ((buNestingDraw) this).GetDirectionVectorFromCornerAndPlane(ref Item);
  }
}
