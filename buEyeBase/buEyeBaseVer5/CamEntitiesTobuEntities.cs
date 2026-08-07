// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.CamEntitiesTobuEntities
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
public class CamEntitiesTobuEntities : buSerilization5
{
  public CamDrillType CamDrillType;
  public CamDrillMode CamDrillMode;
  public actionTypeBU Action;
  public CamMode CamMode;
  public CamRotationType CamRotateType;
  public EntityDevideData DevideData;
  public SortSettings SortingSettings;
  public List<Point3D> ClickList;
  public static byte f00036B;

  public CamEntitiesTobuEntities(bool enable, double tangentAngle, LeadInOutType type, double len)
  {
    ((MWCalculationOptions) this).Enable = false;
    ((MWCalculationOptions) this).TangentAngle = 90.0;
    ((MWCalculationOptions) this).LeadType = LeadInOutType.Arc;
    ((MWCalculationOptions) this).ArcRadius = 10.0;
    ((MWCalculationOptions) this).ArcSweepAngle = 90.0;
    ((MWCalculationOptions) this).Length = 10.0;
    ((MWCalculationOptions) this).ExtendLength = 0.0;
    ((MWCalculationOptions) this).ClockDir = ClockDirectionType.CW;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((MWCalculationOptions) this).Enable = enable;
    ((MWCalculationOptions) this).TangentAngle = tangentAngle;
    ((MWCalculationOptions) this).LeadType = type;
    ((MWCalculationOptions) this).Length = len;
  }

  public CamEntitiesTobuEntities(
    bool enable,
    double tangentAngle,
    LeadInOutType type,
    double len,
    double arcRad,
    double arcSweepAng)
  {
    ((MWCalculationOptions) this).Enable = false;
    ((MWCalculationOptions) this).TangentAngle = 90.0;
    ((MWCalculationOptions) this).LeadType = LeadInOutType.Arc;
    ((MWCalculationOptions) this).ArcRadius = 10.0;
    ((MWCalculationOptions) this).ArcSweepAngle = 90.0;
    ((MWCalculationOptions) this).Length = 10.0;
    ((MWCalculationOptions) this).ExtendLength = 0.0;
    ((MWCalculationOptions) this).ClockDir = ClockDirectionType.CW;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((MWCalculationOptions) this).Enable = enable;
    ((MWCalculationOptions) this).TangentAngle = tangentAngle;
    ((MWCalculationOptions) this).LeadType = type;
    ((MWCalculationOptions) this).Length = len;
    ((MWCalculationOptions) this).ArcRadius = arcRad;
    ((MWCalculationOptions) this).ArcSweepAngle = arcSweepAng;
  }
}
