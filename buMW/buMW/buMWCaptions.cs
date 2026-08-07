// Decompiled with JetBrains decompiler
// Type: buMW.buMWCaptions
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buEyeBaseVer5;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buMW;

public class buMWCaptions
{
  public bool CamLinkEntitiesAsG1;
  public static List<string> FirstEntryType;
  public static List<string> LastExitType;
  public static List<string> MoveHandlingAction;
  public static List<string> LeadInUsage;
  public static List<string> LeadOutUsage;
  public static List<string> LeadInOutUsage;
  public static List<string> LeadParamsType;
  public static List<string> LeadParamsAxisOrientation;
  public static List<string> LeadExtensionParamsType;
  public static List<string> SharpCorners;
  public static List<string> Offset2dContainmentMethod;
  public static List<string> MultiCutsRoughParamsSortType;
  public static List<string> MachiningParamsToolPlaneDirTypeFor3Axis;
  public static List<string> CamOpenContourType;
  public static List<string> CamClosedContourType;
  public static List<string> MachiningParamsMachType;
  public static List<string> MachiningParamsMachiningAreaMode;
  public static List<string> ClockDirectionType;
  public static List<string> WireframeBasedTpCalcParamsRoughType;
  public static List<string> MachiningParamsDirection;
  public static List<string> UseRamp;
  public static List<string> TriangleMeshBasedTpCalcParamsRampType;
  public static List<string> TriangleMeshBasedTpCalcParamsContourPassType;
  public static List<string> TriangleMeshBasedTpCalcParamsFilteringMode;
  public static List<string> TriangleMeshBasedTpCalcParamsFilteringType;
  public static List<string> TriangleMeshBasedTpCalcParamsCornerPegs;
  public static List<string> CollCtrlOpStockParamsStockOffsetMode;
  public static List<string> CollCtrlOpStockParamsStockType;
  public static List<string> CollCtrlOpStockParamsStockAreaLimitOffsetMethod;
  public static List<string> CollCtrlOpStockParamsStockDirection;
  public static List<string> MachiningParamsStockRemainType;
  public static List<string> TriangleMeshBasedTpCalcParamsRoughType;
  public static List<string> WireframeBasedTpCalcParamsFixtureCurveMode;
  public static List<string> CutterRadiusCompParamsCompensationType;
  public static List<string> TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType;
  public static List<string> TriangleMeshBasedTpCalcParamsParallelCutsStartCorner;

  public buMWCaptions(buCamCalcRuntimeSettings data)
  {
    // ISSUE: explicit constructor call
    ((buSerilization5) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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

  public buMWCaptions()
  {
  }
}
