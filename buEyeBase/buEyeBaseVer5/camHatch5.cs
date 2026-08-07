// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camHatch5
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
public class camHatch5 : buSerilization5
{
  public bool LimitsFlg;
  public bool SmoothingFlg;
  public double MaxAngleFromInitialToolOrientation;
  public bool UndercutsFlg;
  public double TiltAngleFixed;
  public double RotaryAngle;
  public bool AxisMeetTiltFlg;

  public camHatch5(camOperation5 data)
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
    ((camOptions5) this).StepHeights.Clear();
    for (int index = 0; index <= ((camOptions5) data).StepHeights.Count - 1; ++index)
      ((camOptions5) this).StepHeights.Add(((camOptions5) data).StepHeights[index]);
  }

  public override string ToString()
  {
    return $"{((camOperation5) this).Height.ToString()} , Direction: {((camOptions5) this).Direction.ToString()}";
  }

  static camHatch5() => camOptions5.Captions = new List<string>();

  public camHatch5()
  {
    ((camOptions5) this).ShowAdvancedPArameters = false;
    ((camOptions5) this).ShpwCoreParameters = false;
    ((camOptions5) this).SelectAllPoints = false;
    ((camOptions5) this).SelectAllDrawings = false;
    ((camOptions5) this).ToolDataToCamData = true;
    ((camOptions5) this).PocketNextContourMaxDistance = 10.0;
    ((camOptions5) this).AxesLimit = new camAxesLimits();
    ((camOptions5) this).StockHeight = 10.0;
    ((camOptions5) this).SpinSpeed = 100.0;
    ((camOptions5) this).FeedFromEntityFeedrate = false;
    ((camOptions5) this).Vacuum1 = false;
    ((camOptions5) this).Vacuum2 = false;
    ((camOptions5) this).Vacuum3 = false;
    ((camRotary5) this).Vacuum4 = false;
    ((camRotary5) this).Vacuum5 = false;
    ((camRotary5) this).Vacuum6 = false;
    ((camRotary5) this).Vacuum7 = false;
    ((camRotary5) this).Vacuum8 = false;
    ((camRotary5) this).WidthXDirection = 0.0;
    ((camRotary5) this).WidthYDirection = 0.0;
    ((camRotary5) this).WidthXYDirection = 0.0;
    ((camRotary5) this).ExtendPatternOutput = 0.0;
    ((camRotary5) this).UseXZPlane = false;
    ((camRotary5) this).StockEnable = false;
    ((camRotary5) this).StockSilhouette = false;
    ((camRotary5) this).StockTolarance = 0.1;
    ((camRotary5) this).StockOffset = 0.0;
    ((camRotary5) this).StockOffsetMode = CamStockOffsetMode.SomExpand;
    ((camRotary5) this).StockType = CamStockType.StBoundingBox;
    ((camRotary5) this).StockSilhouetteType = CamStockSilhouetteType.partEnd;
    ((camRotary5) this).StockOffsetMin = new Point3D();
    ((camRotary5) this).StockOffsetMax = new Point3D();
    ((camRotary5) this).RegenList = new List<RegenResolutionData>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
