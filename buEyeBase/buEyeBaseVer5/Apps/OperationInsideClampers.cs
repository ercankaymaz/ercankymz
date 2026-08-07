// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.OperationInsideClampers
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class OperationInsideClampers : buSerilization5
{
  public int Side;
  public double Diameter;
  public double Angle;
  public static byte f0044E3;
  public ProfileOperationDataCircle CircleData;

  public bool isToolForHole(ToolBase5 Tool)
  {
    return Tool != null && ((ToolGeometry5) Tool).Purpose == ToolPurpose.General | ((ToolGeometry5) Tool).Purpose == ToolPurpose.Milling | ((ToolGeometry5) Tool).Purpose == ToolPurpose.Hole | ((ToolGeometry5) Tool).Purpose == ToolPurpose.Drilling;
  }

  public bool isToolForMilling(ToolBase5 Tool)
  {
    return Tool != null && ((ToolGeometry5) Tool).Purpose == ToolPurpose.General | ((ToolGeometry5) Tool).Purpose == ToolPurpose.Milling | ((ToolGeometry5) Tool).Purpose == ToolPurpose.Cutting | ((ToolGeometry5) Tool).Purpose == ToolPurpose.CutCenter | ((ToolGeometry5) Tool).Purpose == ToolPurpose.CutIn | ((ToolGeometry5) Tool).Purpose == ToolPurpose.CutOut;
  }

  public bool isToolForNotch(ToolBase5 Tool)
  {
    return Tool != null && ((ToolData5) ((ToolGeometry5) Tool).Geometry).GeometryType == ToolType.Saw;
  }

  public bool isToolSuitableForOperation(ProfileOperation OP, ref List<string> Messages)
  {
    bool flag = true;
    Messages.Clear();
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileNotch)
    {
      if (((ProfileRuntimeSettings) OP).ToolNotch == null)
        Messages.Add(buLangTranslate.preSentencesProfile.NotchToolisnotAvailavle);
      if ((((ProfileRuntimeSettings) OP).ToolNotch == null ? 0 : (((ToolData5) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).ToolNotch).Geometry).GeometryType != ToolType.Saw ? 1 : 0)) != 0)
        Messages.Add(buLangTranslate.preSentencesProfile.NotchToolisnotAvailavle);
    }
    else if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileTapping)
    {
      if (((ProfileRuntimeSettings) OP).Tool == null)
        Messages.Add(buLangTranslate.preSentencesProfile.NoTappingToolSelected);
      if (((ProfileRuntimeSettings) OP).ToolAux == null)
        Messages.Add(buLangTranslate.preSentencesProfile.NoHoleToolSelected);
      if ((((ProfileRuntimeSettings) OP).Tool == null ? 0 : (((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Purpose != ToolPurpose.Tapping ? 1 : 0)) != 0)
        Messages.Add(buLangTranslate.preSentencesProfile.NoTappingToolSelected);
      if ((((ProfileRuntimeSettings) OP).ToolAux == null ? 0 : (!this.isToolForHole(((ProfileRuntimeSettings) OP).ToolAux) ? 1 : 0)) != 0)
        Messages.Add(buLangTranslate.preSentencesProfile.NoHoleToolSelected);
    }
    else if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).Action == actionTypeBU.profileHole)
    {
      if (((ProfileRuntimeSettings) OP).Tool == null)
        Messages.Add(buLangTranslate.preSentencesProfile.NoTappingToolSelected);
      if ((((ProfileRuntimeSettings) OP).Tool == null ? 0 : (((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Purpose != ToolPurpose.Drilling & ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Purpose != ToolPurpose.Milling & ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Purpose != 0 ? 1 : 0)) != 0)
        Messages.Add(buLangTranslate.preSentencesProfile.NoHoleToolSelected);
    }
    else
    {
      if (((ProfileRuntimeSettings) OP).Tool == null)
        Messages.Add(buLangTranslate.preSentencesProfile.NoMillingToolSelected);
      if ((((ProfileRuntimeSettings) OP).Tool == null ? 0 : (!this.isToolForMilling(((ProfileRuntimeSettings) OP).Tool) ? 1 : 0)) != 0)
        Messages.Add(buLangTranslate.preSentencesProfile.NoMillingToolSelected);
    }
    if (((ProfileRuntimeSettings) OP).Tool != null)
    {
      if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Top && !((CopyEventFormVars) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Limits).PlaneAll & !((LayerBase5) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Limits).PlaneTop)
        Messages.Add($"{buLangTranslate.preSentencesProfile.ThisPlaneIsNotSuitable} {buLangTranslate.preDef.Top}");
      if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Bottom && !((CopyEventFormVars) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Limits).PlaneAll & !((LayerBase5) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Limits).PlaneBottom)
        Messages.Add($"{buLangTranslate.preSentencesProfile.ThisPlaneIsNotSuitable} {buLangTranslate.preDef.Bottom}");
      if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Front && !((CopyEventFormVars) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Limits).PlaneAll & !((LayerOverride) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Limits).PlaneFront)
        Messages.Add($"{buLangTranslate.preSentencesProfile.ThisPlaneIsNotSuitable} {buLangTranslate.preDef.Front}");
      if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Back && !((CopyEventFormVars) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Limits).PlaneAll & !((LayerOverride) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Limits).PlaneBack)
        Messages.Add($"{buLangTranslate.preSentencesProfile.ThisPlaneIsNotSuitable} {buLangTranslate.preDef.Back}");
      if (((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Free && !((CopyEventFormVars) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Limits).PlaneAll & !((CopyEventFormVars) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Limits).PlaneSlope)
        Messages.Add($"{buLangTranslate.preSentencesProfile.ThisPlaneIsNotSuitable} {buLangTranslate.preDef.Free}");
    }
    return Messages.Count <= 0 && flag;
  }

  public void ToolDataToOPCamData(
    ref ProfileOperationData Data,
    ToolBase5 Tool,
    bool SpeedData = true,
    bool DistanceData = true)
  {
    if (SpeedData)
    {
      ((ProfileArray) Data).CamParMilling.Speeds.Feed = ((ToolLimits5) ((ToolGeometry5) Tool).CamData).FeedSpeed;
      ((ProfileArray) Data).CamParMilling.Speeds.Plunge = ((ToolPositions5) ((ToolGeometry5) Tool).CamData).PlungeSpeed;
      ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) Data).CamParMilling.Speeds).Finish = ((ToolLimits5) ((ToolGeometry5) Tool).CamData).FinishSpeed;
      ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) Data).CamParMilling.Speeds).SpindleSpeed = ((ToolPositions5) ((ToolGeometry5) Tool).CamData).SpindleSpeed;
    }
    if (!DistanceData)
      return;
    ((ProfileArray) Data).CamParMilling.Distances.Safe = ((LayerBase5) ((ToolGeometry5) Tool).CamData).SafeDistance;
    ((camMaterial5) ((ProfileArray) Data).CamParMilling.Distances).Rapid = ((LayerBase5) ((ToolGeometry5) Tool).CamData).RapidDistance;
  }
}
