// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileRuntimeSettings : buSerilization5
{
  public ProfileOperationData OperationData;
  public ProfileOperationCamData CamOPData;
  public List<camTp> CamCalculation;
  public ToolBase5 Tool;
  public BoxSize5 SizePoint;
  public List<ProfileClamper> Clampers;
  public List<buEntity> EntityMultiCam;
  public static byte f004475;
  public double Depth;
  public string ProfileName;
  public double ProfileWidth;
  public double ProfileHeight;
  public double ProfileLength;
  public string Name;
  public string ID;
  public bool Used;
  public bool Enable;
  public bool isClamperOver;
  public bool MoveSafeBeforeOperation;
  public bool MoveSafeAfterOperation;
  public bool Error;
  public bool Selected;
  public bool XRefFromEnd;
  public bool Locked;
  public bool CamAssinged;
  public int Priority;
  public actionTypeBU Action;
  public LeftRightType ParentXReferance;
  public ProfileOperationData OperationData;
  public ProfileOperationCamData CamOPData;
  public List<camTp> CamCalculation;
  public Vector3D CamInsideVector;
  public Vector3D CamOutsideVector;
  public ToolBase5 Tool;
  public ToolBase5 ToolNotch;
  public ToolBase5 ToolAux;
  public Point3D MinPoint;
  public Point3D MaxPoint;
  public Point3D GeoSize;
  public List<ProfileClamper> Clampers;
  public List<buEntity> EntityMultiCam;
  public List<buEntity> EntityMultiCamAux;
  public List<buEntity> EntityMultiContour;
  public List<Entity> EntityMultiSolidDepth;
  public List<buEntity> EntityMultiXYPlane;
  public List<DimensionGroup> EntityDimension;
  public List<string> warningList;
  public List<string> errorList;
  public List<string> infoList;
  public static byte f00449F;
  public double Diameter;
  public static byte f0044A1;
  public double Width;
  public double Height;
  public double Radius;
  public double Chamfer;
  public double Angle;
  public double Width;
  public double Diameter;
  public double Angle;
  public static byte f0044AA;
  public double CutWidth;
  public double CutHeight;
  public double CutDepth;
  public double Angle;
  public static byte f0044AF;
  public double Width;
  public double Height;
  public double Radius;
  public double Angle;
  public static byte f0044B4;
  public double Diameter;
  public double Length;
  public double Width;
  public double Angle;
  public static byte f0044B9;
  public double Width;
  public double Height;
  public double Angle;
  public static byte f0044BD;
  public double Diameter;
  public double DiameterTapping;
  public double DepthTapping;
  public double TappingPitch;
  public double TappingAdditional;
  public bool Tapping;
  public static byte f0044C4;
  public double Width;
  public double Height;
  public double Start;
  public double Angle;
  public UpDownLocationType UpDown;
  public ProfileNotchLocationType NotchLocation;
  public ProfileNotchOperationType OPType;
  public static byte f0044CC;
  public double Width;
  public double Height;
  public double Start;
  public double ToolCutPersentage;
  public ProfileNotchType Type;

  public void ProfileCamDataToCamParameter(
    ProfileOperationCamData CamProfileData,
    ref camParameters5 CamData)
  {
    CamData.Distances.Safe = ((PanelCutSettings) CamProfileData).distanceSafe;
    ((camMaterial5) CamData.Distances).Rapid = ((PanelCutSettings) CamProfileData).distanceRapid;
    CamData.Distances.FirstApproach = ((PanelCutSettings) CamProfileData).distanceFirstApproach;
    CamData.Speeds.Plunge = ((PanelCutSettings) CamProfileData).velPlunge;
    CamData.Speeds.Feed = ((PanelCutSettings) CamProfileData).velFeed;
    ((buEyeBaseVer5.camSpeedsEnable) CamData.Speeds).Finish = ((PanelCutSettings) CamProfileData).velFinish;
    ((buEyeBaseVer5.camSpeedsEnable) CamData.Speeds).Leave = ((PanelCutRuntimeSettings) CamProfileData).velLeave;
    ((camDistances5) CamData.Speeds).AreaClearance = ((PanelCutRuntimeSettings) CamProfileData).velAreaClearance;
    ((camSpeeds5) CamData.Steps).Count = ((PanelCutTempVars) CamProfileData).stepCount;
    ((camSpeeds5) CamData.Steps).Step = ((PanelCutRuntimeSettings) CamProfileData).stepDistance;
    CamData.Steps.Enable = ((PanelCutMoveCommand) CamProfileData).enableStepOperation;
    ((MWCalculationOptions) ((camRuntime5) CamData).LeadIn).Enable = ((PanelCutTempVars) CamProfileData).LeadIn;
    ((MWCalculationOptions) ((camOffset5) CamData).LeadOut).Enable = ((PanelCutTempVars) CamProfileData).LeadOut;
    ((MWCalculationOptions) ((camOffset5) CamData).Notch).NotchCutPersentage = ((PanelCutTempVars) CamProfileData).NotchCutPersentage;
    ((MWCalculationOptions) ((camOffset5) CamData).Notch).NotchCutType = ((PanelCutMoveCommand) CamProfileData).NotchCutType;
    ((camStep5) CamData.Offsets).FinishOffset = ((PanelCutTempVars) CamProfileData).offsetFinish;
    ((camStep5) CamData.Offsets).ClosedContour = ((PanelCutMoveCommand) CamProfileData).typeClosedContour;
    ((camStep5) CamData.Offsets).OpenContour = ((PanelCutMoveCommand) CamProfileData).typeOpenContour;
    ((camOptions5) CamData.Operations).AreaClearanceDirection = ((PanelCutMoveCommand) CamProfileData).AreaClearanceDirection;
    ((camOptions5) CamData.Operations).Direction = ((PanelCutMoveCommand) CamProfileData).directionContour;
    CamData.Operations.AreaClearanceEnable = ((PanelCutTempVars) CamProfileData).enableAreaClearanceOperation;
    CamData.Operations.FinishEnable = ((PanelCutTempVars) CamProfileData).enableFinishOperation;
    CamData.Strategy.OpenContourTwoDirectionCut = ((PanelCutMoveCommand) CamProfileData).enableOpenContourTwoDirectionCutOperation;
  }

  public void AddOperationListsToProfileLists(ref ProfileItem Profile)
  {
    for (int index1 = 0; index1 <= ((ProfileSettings) Profile).Operations.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ((ProfileRuntimeSettings) ((ProfileSettings) Profile).Operations[index1]).warningList.Count - 1; ++index2)
        ((ClamperLeftRightPars) this).AddWarningToProfile(((ProfileRuntimeSettings) ((ProfileSettings) Profile).Operations[index1]).warningList[index2], ref Profile);
      for (int index3 = 0; index3 <= ((ProfileRuntimeSettings) ((ProfileSettings) Profile).Operations[index1]).errorList.Count - 1; ++index3)
        ((ClamperLeftRightPars) this).AddErrorToProfile(((ProfileRuntimeSettings) ((ProfileSettings) Profile).Operations[index1]).errorList[index3], ref Profile);
      for (int index4 = 0; index4 <= ((ProfileRuntimeSettings) ((ProfileSettings) Profile).Operations[index1]).infoList.Count - 1; ++index4)
        ((ClamperLeftRightPars) this).AddInfoToProfile(((ProfileRuntimeSettings) ((ProfileSettings) Profile).Operations[index1]).infoList[index4], ref Profile);
    }
  }
}
