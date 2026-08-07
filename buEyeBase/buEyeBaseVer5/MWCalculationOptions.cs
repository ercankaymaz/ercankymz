// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MWCalculationOptions
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class MWCalculationOptions : buSerilization5
{
  public double NotchCutPersentage;
  public UpDownDirectionType CutDirection;
  public ProfileNotchCutType NotchCutType;
  public CamCuttingWayDirectionType NotchCutDirection;
  public static byte f00031A;
  public bool Enable;
  public double TangentAngle;
  public LeadInOutType LeadType;
  public double ArcRadius;
  public double ArcSweepAngle;
  public double Length;
  public double ExtendLength;
  public ClockDirectionType ClockDir;
  public static List<string> Captions;
  public static byte f000324;
  public bool Enable;
  public double TangentAngle;
  public LeadInOutType LeadType;
  public double ArcRadius;
  public double ArcSweepAngle;
  public double Length;
  public double ExtendLength;
  public ClockDirectionType ClockDir;
  public static List<string> Captions;
  public List<CalculationError> Errors;
  public List<Entity> UsedEntities;
  public bool AddToCamListInMWCalculation;
  public bool AddToCamListInLocalCalculation;
  public bool DontApplyReset;
  public bool UseStartPoint;
  public bool HeightFromEntities;
  public bool UseConstantStartPoint;
  public bool UseEachCurveStartPoint;
  public bool Editing;
  public bool is5AxisWireframe;
  public bool isAllG1;
  public double StartPointX;
  public double StartPointY;
  public double StartZ;
  public double Height;
  public double Depth;
  public double WireframeRoughtStepOverParaelelOverride;
  public double CurveEntityRegenDeviation;
  public double SolidEntityRegenDeviation;
  public double RapidDistance;
  public double SafeDistance;
  public bool isPointDistrubition;
  public bool isClosed;
  public bool isRough;
  public bool isBuWireframeCalculation;
  public bool isTriangularMeshAdvanced;
  public bool isSpinCalculation;
  public bool isSpinConstantCalculation;
  public bool isBuSort;
  public bool Reverse;
  public bool DontShowDialogBox;
  public bool DontShowbuDialogBox;
  public bool UseSortedAndSplitedEntities;
  public bool CheckBoxBounding;

  public MWCalculationOptions(bool enable, double tangentAngle, LeadInOutType type, double len)
  {
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    this.Enable = enable;
    this.TangentAngle = tangentAngle;
    this.LeadType = type;
    this.Length = len;
  }

  public MWCalculationOptions(
    bool enable,
    double tangentAngle,
    LeadInOutType type,
    double len,
    double arcRad,
    double arcSweepAng)
  {
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    this.Enable = enable;
    this.TangentAngle = tangentAngle;
    this.LeadType = type;
    this.Length = len;
    this.ArcRadius = arcRad;
    this.ArcSweepAngle = arcSweepAng;
  }
}
