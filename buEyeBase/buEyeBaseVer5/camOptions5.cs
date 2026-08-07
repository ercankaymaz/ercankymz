// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camOptions5
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
public class camOptions5 : buSerilization5
{
  public bool MakeCenterOffset;
  public bool isClosed;
  public bool SpiralMode;
  public bool isCircularCam;
  public Point3D BorderMinOffset;
  public Point3D BorderMaxOffset;
  public ClockDirectionType Direction;
  public InToOutType AreaClearanceDirection;
  public CamSafeForPlunge SafePlungeForFirstPoint;
  public CamSafeForLeave SafeLeaveForLastPoint;
  public CamSafeForPlunge SafePlungeForContoutToContour;
  public CamSafeForLeave SafeLeaveForContoutToContour;
  public CamSafeForPlunge SafePlungeForIfLastAndNextPointSameXY;
  public CamSafeForLeave SafeLeaveForIfLastAndNextPointSameXY;
  public bool PocketStepToStepSmallSafe;
  public Pnt6D Point;
  public double Thickness;
  public double TargetZ;
  public List<double> StepHeights;
  public static List<string> Captions;
  public static byte f000264;
  public bool ShowAdvancedPArameters;
  public bool ShpwCoreParameters;
  public bool SelectAllPoints;
  public bool SelectAllDrawings;
  public bool ToolDataToCamData;
  public double PocketNextContourMaxDistance;
  public camAxesLimits AxesLimit;
  public double StockHeight;
  public double SpinSpeed;
  public bool FeedFromEntityFeedrate;
  public bool Vacuum1;
  public bool Vacuum2;
  public bool Vacuum3;

  public override string ToString() => "Enable: " + ((camOperation5) this).Enable.ToString();

  static camOptions5() => camOperation5.Captions = new List<string>();

  public camOptions5()
  {
    ((camOperation5) this).Enable = false;
    ((camOperation5) this).UsePoints = false;
    ((camOperation5) this).StepOverPersentage = 90.0;
    ((camOperation5) this).PocketType = CamPocketType.WfbRghtOffset;
    ((camOperation5) this).PocketInOut = InToOutType.OutToIn;
    ((camOperation5) this).SharpCorner = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public camOptions5(camPocket5 distance)
  {
    ((camOperation5) this).Enable = false;
    ((camOperation5) this).UsePoints = false;
    ((camOperation5) this).StepOverPersentage = 90.0;
    ((camOperation5) this).PocketType = CamPocketType.WfbRghtOffset;
    ((camOperation5) this).PocketInOut = InToOutType.OutToIn;
    ((camOperation5) this).SharpCorner = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) distance, ref CopiedClass);
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
