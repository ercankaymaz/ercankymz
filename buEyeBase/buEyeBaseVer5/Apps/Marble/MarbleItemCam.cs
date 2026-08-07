// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleItemCam
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buEyeBaseVer5.Apps.PanelCut;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleItemCam : buSerilization5
{
  public static bool DontMoveClamperForPark;
  public int LastGCodeLine;
  public static ProfileMultiSelectedOperation MultiSelectedProps;
  public static List<buEyeBaseVer5.Apps.ProfileOperation> SelectedOperations;
  public static List<DepthPositions> OperationDepths;
  public List<MacroItem> Macros;
  public static List<buEyeBaseVer5.Apps.ProfileClamper> LastClampers;
  public static byte f004609;
  public int MaterialTranspancy;
  public double EachLayerSafeDistance;
  public double EachLayerMinThickness;
  public double EachLayerMaxThickness;
  public bool EachLayerFromArea;
  public int EachLayerAreaDevideCount;
  public double EachLayerConnectGap;
  public int ProfileMaxClamper;
  public Color SupportBlockZColor;
  public Color ProfileColor;
  public bool FindToolAuto;
  public bool FindToolAutoFromDepth;
  public double MinXMove;
  public double MinYMove;
  public double MinZMove;
  public double MinAMove;
  public double MaxXMove;
  public double MaxYMove;
  public double MaxZMove;
  public double MaxAMove;
  public bool ShowToolChangeInSimulation;
  public double ToolChangeX;
  public double ToolChangeY;
  public double ToolChangeZ;
  public double ToolChangeA;
  public double MachineLength;
  public double CutQuality;
  public bool ConnectSmallGap;
  public double GapConnectionForProfile;
  public double ProfileSortResolution;
  public double MinProfileFilterLength;
  public SortingIntersectionRulesType IntersectionRules;
  public double ProfileSizeExceedDepthLimit;
  public bool CalculateClamperEveryTime;

  public abstract void m001E6F();

  public MarbleItemCam()
  {
    ((PanelCutSettings) this).distanceSafe = 50.0;
    ((PanelCutSettings) this).distanceRapid = 20.0;
    ((PanelCutSettings) this).distanceFirstApproach = 30.0;
    ((PanelCutSettings) this).velPlunge = 30.0;
    ((PanelCutSettings) this).velFeed = 50.0;
    ((PanelCutSettings) this).velFinish = 40.0;
    ((PanelCutRuntimeSettings) this).velLeave = 100.0;
    ((PanelCutRuntimeSettings) this).velAreaClearance = 60.0;
    ((PanelCutRuntimeSettings) this).stepDistance = 1.0;
    ((PanelCutTempVars) this).stepCount = 1;
    ((PanelCutTempVars) this).NotchCutPersentage = 90.0;
    ((PanelCutTempVars) this).NotchSafeDistance = 50.0;
    ((PanelCutTempVars) this).offsetFinish = 1.0;
    ((PanelCutTempVars) this).LeadIn = false;
    ((PanelCutTempVars) this).LeadOut = false;
    ((PanelCutTempVars) this).enableAreaClearanceOperation = false;
    ((PanelCutTempVars) this).enableFinishOperation = false;
    ((PanelCutMoveCommand) this).enableStepOperation = false;
    ((PanelCutMoveCommand) this).enableOpenContourTwoDirectionCutOperation = false;
    ((PanelCutMoveCommand) this).AreaClearanceDirection = InToOutType.InToOut;
    ((PanelCutMoveCommand) this).directionContour = ClockDirectionType.CW;
    ((PanelCutMoveCommand) this).typeClosedContour = CamClosedContourType.Inner;
    ((PanelCutMoveCommand) this).typeOpenContour = CamOpenContourType.Center;
    ((PanelCutMoveCommand) this).NotchCutType = ProfileNotchCutType.BySaw;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MarbleItemCam(ProfileOperationCamData data)
  {
    ((PanelCutSettings) this).distanceSafe = 50.0;
    ((PanelCutSettings) this).distanceRapid = 20.0;
    ((PanelCutSettings) this).distanceFirstApproach = 30.0;
    ((PanelCutSettings) this).velPlunge = 30.0;
    ((PanelCutSettings) this).velFeed = 50.0;
    ((PanelCutSettings) this).velFinish = 40.0;
    ((PanelCutRuntimeSettings) this).velLeave = 100.0;
    ((PanelCutRuntimeSettings) this).velAreaClearance = 60.0;
    ((PanelCutRuntimeSettings) this).stepDistance = 1.0;
    ((PanelCutTempVars) this).stepCount = 1;
    ((PanelCutTempVars) this).NotchCutPersentage = 90.0;
    ((PanelCutTempVars) this).NotchSafeDistance = 50.0;
    ((PanelCutTempVars) this).offsetFinish = 1.0;
    ((PanelCutTempVars) this).LeadIn = false;
    ((PanelCutTempVars) this).LeadOut = false;
    ((PanelCutTempVars) this).enableAreaClearanceOperation = false;
    ((PanelCutTempVars) this).enableFinishOperation = false;
    ((PanelCutMoveCommand) this).enableStepOperation = false;
    ((PanelCutMoveCommand) this).enableOpenContourTwoDirectionCutOperation = false;
    ((PanelCutMoveCommand) this).AreaClearanceDirection = InToOutType.InToOut;
    ((PanelCutMoveCommand) this).directionContour = ClockDirectionType.CW;
    ((PanelCutMoveCommand) this).typeClosedContour = CamClosedContourType.Inner;
    ((PanelCutMoveCommand) this).typeOpenContour = CamOpenContourType.Center;
    ((PanelCutMoveCommand) this).NotchCutType = ProfileNotchCutType.BySaw;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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

  public override string ToString()
  {
    string str = $"Safe Dis: {((PanelCutSettings) this).distanceSafe.ToString()} , Small Safe: {((PanelCutSettings) this).distanceRapid.ToString()} , Offset Type: {((PanelCutMoveCommand) this).typeClosedContour.ToString()}";
    if (((PanelCutMoveCommand) this).enableStepOperation)
      str = $"{str}Step Dis : {((PanelCutRuntimeSettings) this).stepDistance.ToString()} , Count: {((PanelCutTempVars) this).stepCount.ToString()}";
    return str;
  }

  public static ArrayList ToDefPars(ProfileOperationCamData P, string Char, int Space)
  {
    string str = "ProfileOperationCamDataPars";
    if (Char.Trim().Length > 0)
      str = Char;
    return new ArrayList()
    {
      (object) $"{buImage5.SpaceChar(Space)}<{str}",
      (object) (buImage5.SpaceChar(Space + 2) + MarbleItemCam.ToDefPars(P)),
      (object) $"{buImage5.SpaceChar(Space)}</{str}"
    };
  }

  public static ArrayList ToDefPars(ProfileOperationCamData P, int Space)
  {
    return new ArrayList()
    {
      (object) (buImage5.SpaceChar(Space) + "<ProfileOperationCamDataPars>"),
      (object) (buImage5.SpaceChar(Space + 2) + MarbleItemCam.ToDefPars(P)),
      (object) (buImage5.SpaceChar(Space) + "</ProfileOperationCamDataPars>")
    };
  }

  public static string ToDefPars(ProfileOperationCamData P)
  {
    return buSerilization5.ClassToString((object) P);
  }

  public abstract void m001E76();
}
