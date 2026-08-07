// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camRotary5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class camRotary5 : buSerilization5
{
  public bool Vacuum4;
  public bool Vacuum5;
  public bool Vacuum6;
  public bool Vacuum7;
  public bool Vacuum8;
  public double WidthXDirection;
  public double WidthYDirection;
  public double WidthXYDirection;
  public double ExtendPatternOutput;
  public bool UseXZPlane;
  public bool StockEnable;
  public bool StockSilhouette;
  public double StockTolarance;
  public double StockOffset;
  public CamStockOffsetMode StockOffsetMode;
  public CamStockType StockType;
  public CamStockSilhouetteType StockSilhouetteType;
  public Point3D StockOffsetMin;
  public Point3D StockOffsetMax;
  public List<RegenResolutionData> RegenList;
  public static List<string> Captions;
  public static byte f000287;
  public CamTiltStrategy TiltStrategy;
  public CamSideTiltDefTypes SideTiltDefTypes;
  public double LagAngle;
  public double SideTiltAngle;
  public double MaxAngleChange;

  public override string ToString() => "Enable: " + ((camOperation5) this).Enable.ToString();

  static camRotary5() => camOperation5.Captions = new List<string>();

  public camRotary5()
  {
    ((camOperation5) this).Height = 0.0;
    ((camOperation5) this).Depth = 0.0;
    ((camOperation5) this).DepthUp = 0.0;
    ((camOperation5) this).Width = 0.0;
    ((camOperation5) this).BaseThickness = 0.0;
    ((camOperation5) this).Overlap = 0.0;
    ((camOperation5) this).Stepover = 0.0;
    ((camOperation5) this).SurfaceOffset = 0.0;
    ((camOperation5) this).FinishEnable = false;
    ((camOperation5) this).AreaClearanceEnable = false;
    ((camOptions5) this).MakeCenterOffset = false;
    ((camOptions5) this).isClosed = false;
    ((camOptions5) this).SpiralMode = false;
    ((camOptions5) this).isCircularCam = false;
    ((camOptions5) this).BorderMinOffset = new Point3D();
    ((camOptions5) this).BorderMaxOffset = new Point3D();
    ((camOptions5) this).Direction = ClockDirectionType.CCW;
    ((camOptions5) this).AreaClearanceDirection = InToOutType.OutToIn;
    ((camOptions5) this).SafePlungeForFirstPoint = CamSafeForPlunge.Safe;
    ((camOptions5) this).SafeLeaveForLastPoint = CamSafeForLeave.Safe;
    ((camOptions5) this).SafePlungeForContoutToContour = CamSafeForPlunge.Safe;
    ((camOptions5) this).SafeLeaveForContoutToContour = CamSafeForLeave.Safe;
    ((camOptions5) this).SafePlungeForIfLastAndNextPointSameXY = CamSafeForPlunge.None;
    ((camOptions5) this).SafeLeaveForIfLastAndNextPointSameXY = CamSafeForLeave.None;
    ((camOptions5) this).PocketStepToStepSmallSafe = true;
    ((camOptions5) this).Point = new Pnt6D();
    ((camOptions5) this).Thickness = 0.0;
    ((camOptions5) this).TargetZ = 0.0;
    ((camOptions5) this).StepHeights = new List<double>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public camRotary5(double height, ClockDirectionType direction)
  {
    ((camOperation5) this).Height = 0.0;
    ((camOperation5) this).Depth = 0.0;
    ((camOperation5) this).DepthUp = 0.0;
    ((camOperation5) this).Width = 0.0;
    ((camOperation5) this).BaseThickness = 0.0;
    ((camOperation5) this).Overlap = 0.0;
    ((camOperation5) this).Stepover = 0.0;
    ((camOperation5) this).SurfaceOffset = 0.0;
    ((camOperation5) this).FinishEnable = false;
    ((camOperation5) this).AreaClearanceEnable = false;
    ((camOptions5) this).MakeCenterOffset = false;
    ((camOptions5) this).isClosed = false;
    ((camOptions5) this).SpiralMode = false;
    ((camOptions5) this).isCircularCam = false;
    ((camOptions5) this).BorderMinOffset = new Point3D();
    ((camOptions5) this).BorderMaxOffset = new Point3D();
    ((camOptions5) this).Direction = ClockDirectionType.CCW;
    ((camOptions5) this).AreaClearanceDirection = InToOutType.OutToIn;
    ((camOptions5) this).SafePlungeForFirstPoint = CamSafeForPlunge.Safe;
    ((camOptions5) this).SafeLeaveForLastPoint = CamSafeForLeave.Safe;
    ((camOptions5) this).SafePlungeForContoutToContour = CamSafeForPlunge.Safe;
    ((camOptions5) this).SafeLeaveForContoutToContour = CamSafeForLeave.Safe;
    ((camOptions5) this).SafePlungeForIfLastAndNextPointSameXY = CamSafeForPlunge.None;
    ((camOptions5) this).SafeLeaveForIfLastAndNextPointSameXY = CamSafeForLeave.None;
    ((camOptions5) this).PocketStepToStepSmallSafe = true;
    ((camOptions5) this).Point = new Pnt6D();
    ((camOptions5) this).Thickness = 0.0;
    ((camOptions5) this).TargetZ = 0.0;
    ((camOptions5) this).StepHeights = new List<double>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((camOperation5) this).Height = height;
    ((camOptions5) this).Direction = direction;
  }
}
