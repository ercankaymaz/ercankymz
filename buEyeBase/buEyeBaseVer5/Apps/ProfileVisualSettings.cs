// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileVisualSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using System;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileVisualSettings : buSerilization5
{
  public static byte f004458;
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
  public bool isCollision;
  public bool Calculated;
  public bool Selected;
  public int Priority;
  public int ClamperIndex;
  public int CollisionClamperIndex;
  public actionTypeBU Action;
  public LeftRightType XReferanceLocation;

  public void buShapeToProfileData(
    ShapeRuntimeData shapeRuntimeData,
    ref ProfileOperationData OPData,
    ref actionTypeBU Action)
  {
    Action = actionTypeBU.None;
    if (shapeRuntimeData.ShapeType == ShapeTypes.Rectangle)
    {
      Action = actionTypeBU.profileRectangle;
      ((CreateProfileFromDataOptions) ((DepthPositions) OPData).RectangleData).RectangleWidth = ((CurveToSurfaceSettingsType) shapeRuntimeData).RectangleWidth;
      ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleHeight = ((CurveToSurfaceSettingsType) shapeRuntimeData).RectangleHeight;
      ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleAngle = ((SelectedPlaneInfo) shapeRuntimeData).RectangleAngle;
      ((ProfileArray) OPData).ExternalDepth = ((SelectedPlaneInfo) shapeRuntimeData).RectangleDepth;
      ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleRadius = ((SelectedPlaneInfo) shapeRuntimeData).RectangleRadius;
      ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleChamfer = ((SelectedPlaneInfo) shapeRuntimeData).RectangleChamfer;
      ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleAngle = ((ShapeRuntimeData) shapeRuntimeData.Edit).RotateDegree;
    }
    if (shapeRuntimeData.ShapeType == ShapeTypes.Circle)
    {
      Action = actionTypeBU.profileCircle;
      ((CreateProfileFromDataOptions) ((OperationInsideClampers) OPData).CircleData).CircleDiameter = ((SelectedPlaneInfo) shapeRuntimeData).CircleRadius * 2.0;
      ((ProfileArray) OPData).ExternalDepth = ((SelectedPlaneInfo) shapeRuntimeData).CircleDepth;
    }
    if (shapeRuntimeData.ShapeType == ShapeTypes.Hole)
    {
      Action = actionTypeBU.profileHole;
      ((NestingPanel) ((DepthPositions) OPData).HoleData).HoleDiameter = ((SelectionEntity) shapeRuntimeData).HoleDiameter;
      ((ProfileArray) OPData).ExternalDepth = ((SelectionEntity) shapeRuntimeData).HoleDepth;
      ((NestingPanelNode) ((DepthPositions) OPData).HoleData).TappingDepth = ((MeasureData) shapeRuntimeData).TappingDepth;
      ((NestingPanelNode) ((DepthPositions) OPData).HoleData).TappingDiameter = ((MeasureItem) shapeRuntimeData).TappingDiameter;
      ((NestingPanelNode) ((DepthPositions) OPData).HoleData).TappingPitch = ((MeasureItem) shapeRuntimeData).TappingPitch;
      if (shapeRuntimeData.isTapping)
        Action = actionTypeBU.profileTapping;
    }
    if (shapeRuntimeData.ShapeType == ShapeTypes.Ellipse)
    {
      Action = actionTypeBU.profileEllipse;
      ((NestingPanelJob) ((DepthPositions) OPData).EllipseData).EllipseWidth = ((SelectedPlaneInfo) shapeRuntimeData).EllipseRadiusX * 2.0;
      ((NestingPanelJob) ((DepthPositions) OPData).EllipseData).EllipseHeight = ((SelectedPlaneInfo) shapeRuntimeData).EllipseRadiusY * 2.0;
      ((NestingPanelJob) ((DepthPositions) OPData).EllipseData).EllipseAngle = ((ShapeRuntimeData) shapeRuntimeData.Edit).RotateDegree;
      ((ProfileArray) OPData).ExternalDepth = ((SelectedPlaneInfo) shapeRuntimeData).EllipseDepth;
    }
    if (shapeRuntimeData.ShapeType == ShapeTypes.KeyHole)
    {
      Action = actionTypeBU.profileBarrel;
      ((PanelCutMove) ((DepthPositions) OPData).BarelData).BarrelDiameter = ((SelectionEntityTypes) shapeRuntimeData).KeyHoleHeadDiameter;
      ((PanelCutMove) ((DepthPositions) OPData).BarelData).BarrelLength = ((SelectionEntityTypes) shapeRuntimeData).KeyHoleLength;
      ((PanelCutMove) ((DepthPositions) OPData).BarelData).BarrelWidth = ((SelectionEntityTypes) shapeRuntimeData).KeyHoleDiameter;
      ((PanelCutMove) ((DepthPositions) OPData).BarelData).BarrelAngle = ((ShapeRuntimeData) shapeRuntimeData.Edit).RotateDegree;
      ((ProfileArray) OPData).ExternalDepth = ((SelectionOperation) shapeRuntimeData).KeyHoleDepth;
    }
    if (shapeRuntimeData.ShapeType == ShapeTypes.Polygon)
    {
      Action = actionTypeBU.profilePolygon;
      ((CreateProfileFromDataOptions) ((DepthPositionOptions) OPData).PolygonData).PolygonDiameter = ((SelectedPlaneInfo) shapeRuntimeData).PolygonRadius * 2.0;
      ((CreateProfileFromDataOptions) ((DepthPositionOptions) OPData).PolygonData).PolygonSide = ((SelectedPlaneInfo) shapeRuntimeData).PolygonSide;
      ((CreateProfileFromDataOptions) ((DepthPositionOptions) OPData).PolygonData).PolygonAngle = ((ShapeRuntimeData) shapeRuntimeData.Edit).RotateDegree;
      ((ProfileArray) OPData).ExternalDepth = ((SelectedPlaneInfo) shapeRuntimeData).PolygonDepth;
    }
    if (shapeRuntimeData.ShapeType == ShapeTypes.Cut)
    {
      Action = actionTypeBU.profileCut;
      ((PanelDonePart) ((DepthPositions) OPData).CutData).CutWidth = ((MeasureData) shapeRuntimeData).CutDiameter;
      ((PanelDonePart) ((DepthPositions) OPData).CutData).CutHeigth = ((MeasureData) shapeRuntimeData).CutLength;
      ((PanelWaitAssembly) ((DepthPositions) OPData).CutData).CutAngle = ((ShapeRuntimeData) shapeRuntimeData.Edit).RotateDegree;
      ((ProfileArray) OPData).ExternalDepth = ((MeasureData) shapeRuntimeData).CutDepth;
    }
    if (shapeRuntimeData.ShapeType == ShapeTypes.Slot)
    {
      Action = actionTypeBU.profileSlot;
      ((PanelEntityData) ((DepthPositions) OPData).SlotData).SlotDiameter = ((SelectionEntityTypes) shapeRuntimeData).SlotDiameter;
      ((PanelEntityData) ((DepthPositions) OPData).SlotData).SlotWidth = ((SelectedPlaneInfo) shapeRuntimeData).SlotLength;
      ((PanelEntityData) ((DepthPositions) OPData).SlotData).SlotAngle = ((ShapeRuntimeData) shapeRuntimeData.Edit).RotateDegree;
      ((ProfileArray) OPData).ExternalDepth = ((SelectionEntityTypes) shapeRuntimeData).SlotDepth;
    }
    if (shapeRuntimeData.ShapeType == ShapeTypes.FreeDraw)
    {
      Action = actionTypeBU.profileFreeDraw;
      ((NestingPanelNode) ((DepthPositionOptions) OPData).FreeDrawData).FreeDrawWidth = ((SelectionOperation) shapeRuntimeData).FreeDrawWidth;
      ((NestingPanelNode) ((DepthPositionOptions) OPData).FreeDrawData).FreeDrawHeight = ((SelectionOperation) shapeRuntimeData).FreeDrawHeight;
      ((ProfileArray) OPData).ExternalDepth = ((SelectionOperation) shapeRuntimeData).FreeDrawDepth;
      ((NestingPanelNode) ((DepthPositionOptions) OPData).FreeDrawData).FreeDrawAngle = ((ShapeRuntimeData) shapeRuntimeData.Edit).RotateDegree;
    }
    if (shapeRuntimeData.ShapeType == ShapeTypes.Text)
    {
      Action = actionTypeBU.profileText;
      ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).TextWidth = ((SelectionEntity) shapeRuntimeData).TextWidth;
      ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).TextHeight = ((SelectionEntity) shapeRuntimeData).TextHeight;
      ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).TextString = ((SelectionEntity) shapeRuntimeData).TextString;
      ((ProfileArray) OPData).ExternalDepth = ((SelectionEntity) shapeRuntimeData).TextDepth;
      ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).TextFont = new Font(((SelectionEntity) shapeRuntimeData).TextFont.Name, ((SelectionEntity) shapeRuntimeData).TextFont.Size, ((SelectionEntity) shapeRuntimeData).TextFont.Style);
      ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).isWire = ((SelectionEntity) shapeRuntimeData).TextIsWire;
      if (((SelectionEntity) shapeRuntimeData).TextIsWire)
        Action = actionTypeBU.profileWireText;
      ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).TextAngle = ((ShapeRuntimeData) shapeRuntimeData.Edit).RotateDegree;
    }
    if (shapeRuntimeData.ShapeType == ShapeTypes.Notch)
    {
      Action = actionTypeBU.profileNotch;
      ((NestingPanelJob) ((DepthPositions) OPData).NotchData).NotchWidth = ((CustomDataAdd) shapeRuntimeData).NotchWidth;
      ((NestingPanelJob) ((DepthPositions) OPData).NotchData).NotchHeight = ((CustomDataAdd) shapeRuntimeData).NotchHeight;
      ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchStart = ((MachineConfigSettings) shapeRuntimeData).NotchStartHeight;
      ((NestingPanelJob) ((DepthPositions) OPData).NotchData).NotchDepth = ((MachineConfigSettings) shapeRuntimeData).NotchDepth;
      ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchUpDown = ((dynamicInfo) shapeRuntimeData).NotchUpDown;
      ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchFrontBack = ((dynamicInfo) shapeRuntimeData).NotchFrontBack;
      ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchOPType = ((dynamicInfo) shapeRuntimeData).NotchOPType;
      if (((NestingPanel) ((DepthPositions) OPData).NotchData).NotchOPType == ProfileNotchOperationType.Side | ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchOPType == ProfileNotchOperationType.Vertical | ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchOPType == ProfileNotchOperationType.Horizontal)
        ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchLocation = ((dynamicInfo) shapeRuntimeData).NotchSideLocation;
      else
        ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchLocation = ((dynamicInfo) shapeRuntimeData).NotchLengthLocation;
    }
    ((ProfileOnlineOpOptions) OPData).basePosition.X = shapeRuntimeData.pntBase.X;
    ((ProfileOnlineOpOptions) OPData).basePosition.Y = shapeRuntimeData.pntBase.Y;
    ((ProfileOnlineOpOptions) OPData).basePosition.Z = shapeRuntimeData.pntBase.Z;
    ((ProfileMirror) OPData).selectedPlaneName = (planeNames) Convert.ToInt32((object) shapeRuntimeData.selectedPlane);
    ((ProfilePatternCopy) OPData).selectedPlane = buCall.\u0001.PlaneNameToPlane(shapeRuntimeData.selectedPlane);
    if (shapeRuntimeData.Edit != null)
    {
      ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).LineerEnable = ((ShapeRuntimeData) ((ShapeRuntimeData) shapeRuntimeData.Edit).ArrayData).LineerEnable;
      ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).CircularEnable = ((ShapeRuntimeData) ((ShapeRuntimeData) shapeRuntimeData.Edit).ArrayData).CircularEnable;
      ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Mirror).MirrorEnable = ((ShapeRuntimeData) ((ShapeRuntimeData) shapeRuntimeData.Edit).MirrorData).MirrorEnable;
      if (((ShapeRuntimeData) ((ShapeRuntimeData) shapeRuntimeData.Edit).ArrayData).LineerEnable)
      {
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).LineerEnable = true;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).LineerXCount = ((ShapeRuntimeData) ((ShapeRuntimeData) shapeRuntimeData.Edit).ArrayData).LineerXCount;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).LineerXDistance = ((ShapeRuntimeData) ((ShapeRuntimeData) shapeRuntimeData.Edit).ArrayData).LineerXDistance;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).LineerYCount = ((ShapeRuntimeData) ((ShapeRuntimeData) shapeRuntimeData.Edit).ArrayData).LineerYCount;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).LineerYDistance = ((ShapeRuntimeData) ((ShapeRuntimeData) shapeRuntimeData.Edit).ArrayData).LineerYDistance;
      }
      if (((ShapeRuntimeData) ((ShapeRuntimeData) shapeRuntimeData.Edit).ArrayData).CircularEnable)
      {
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).CircularEnable = true;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).CircularCount = ((ShapeRuntimeData) ((ShapeRuntimeData) shapeRuntimeData.Edit).ArrayData).CircularCount;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).CircularAngle = ((ShapeRuntimeData) ((ShapeRuntimeData) shapeRuntimeData.Edit).ArrayData).CircularAngle;
      }
      if (((ShapeRuntimeData) ((ShapeRuntimeData) shapeRuntimeData.Edit).MirrorData).MirrorEnable)
      {
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Mirror).MirrorEnable = true;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Mirror).MirrorDistance = ((ShapeRuntimeData) ((ShapeRuntimeData) shapeRuntimeData.Edit).MirrorData).MirrorDistance;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Mirror).MirrorLocation = ((ShapeRuntimeData) ((ShapeRuntimeData) shapeRuntimeData.Edit).MirrorData).MirrorLocation;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Mirror).MirrorMode = ((ShapeRuntimeData) ((ShapeRuntimeData) shapeRuntimeData.Edit).MirrorData).MirrorMode;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Mirror).MirrorAxis = ((ShapeRuntimeData) ((ShapeRuntimeData) shapeRuntimeData.Edit).MirrorData).MirrorAxis;
      }
    }
    ((ProfileMirror) OPData).EachLayer = ((ShapeTempData) shapeRuntimeData).EachLayer;
    ((ProfileMirror) OPData).ManuelZEnable = ((ShapeTempData) shapeRuntimeData).ManuelDepthEnable;
    ((ProfileArray) OPData).ManuelZVal = ((CurveToSurfaceSettingsType) shapeRuntimeData).ManuelDepthStart;
    ((ProfileArray) OPData).IncrementalDistance = ((CurveToSurfaceSettingsType) shapeRuntimeData).IncrementalDistance;
    ((ProfileArray) OPData).ExtraDepth = ((CurveToSurfaceSettingsType) shapeRuntimeData).ExtraDepth;
    ((CreateProfileFromDataOptions) OPData).Alignment = shapeRuntimeData.objectAlignment;
    ((CreateProfileFromDataOptions) OPData).Corner = shapeRuntimeData.selectedCorner;
    if (shapeRuntimeData.ShapeType == ShapeTypes.Notch)
    {
      ((ProfileArray) OPData).CamParNotch = (camParameters5) new camRuntime5(shapeRuntimeData.CamPars);
    }
    else
    {
      ((ProfileArray) OPData).CamParMilling = (camParameters5) new camRuntime5(shapeRuntimeData.CamPars);
      ((ProfileArray) OPData).CamParMilling.Operations.AreaClearanceEnable = shapeRuntimeData.isShapePocket;
    }
    ((CreateProfileFromDataOptions) OPData).Action = Action;
  }

  public void CamParameterToProfileCamData(
    camParameters5 CamData,
    ref ProfileOperationCamData CamProfileData)
  {
    ((PanelCutSettings) CamProfileData).distanceSafe = CamData.Distances.Safe;
    ((PanelCutSettings) CamProfileData).distanceRapid = ((camMaterial5) CamData.Distances).Rapid;
    ((PanelCutSettings) CamProfileData).distanceFirstApproach = CamData.Distances.FirstApproach;
    ((PanelCutSettings) CamProfileData).velPlunge = CamData.Speeds.Plunge;
    ((PanelCutSettings) CamProfileData).velFeed = CamData.Speeds.Feed;
    ((PanelCutSettings) CamProfileData).velFinish = ((buEyeBaseVer5.camSpeedsEnable) CamData.Speeds).Finish;
    ((PanelCutRuntimeSettings) CamProfileData).velAreaClearance = ((camDistances5) CamData.Speeds).AreaClearance;
    ((PanelCutRuntimeSettings) CamProfileData).velLeave = ((buEyeBaseVer5.camSpeedsEnable) CamData.Speeds).Leave;
    ((PanelCutTempVars) CamProfileData).stepCount = ((camSpeeds5) CamData.Steps).Count;
    ((PanelCutRuntimeSettings) CamProfileData).stepDistance = ((camSpeeds5) CamData.Steps).Step;
    ((PanelCutMoveCommand) CamProfileData).enableStepOperation = CamData.Steps.Enable;
    ((PanelCutTempVars) CamProfileData).LeadIn = ((MWCalculationOptions) ((camRuntime5) CamData).LeadIn).Enable;
    ((PanelCutTempVars) CamProfileData).LeadOut = ((MWCalculationOptions) ((camOffset5) CamData).LeadOut).Enable;
    ((PanelCutTempVars) CamProfileData).NotchCutPersentage = ((MWCalculationOptions) ((camOffset5) CamData).Notch).NotchCutPersentage;
    ((PanelCutTempVars) CamProfileData).offsetFinish = ((camStep5) CamData.Offsets).FinishOffset;
    ((PanelCutMoveCommand) CamProfileData).typeClosedContour = ((camStep5) CamData.Offsets).ClosedContour;
    ((PanelCutMoveCommand) CamProfileData).typeOpenContour = ((camStep5) CamData.Offsets).OpenContour;
    ((PanelCutMoveCommand) CamProfileData).AreaClearanceDirection = ((camOptions5) CamData.Operations).AreaClearanceDirection;
    ((PanelCutMoveCommand) CamProfileData).directionContour = ((camOptions5) CamData.Operations).Direction;
    ((PanelCutTempVars) CamProfileData).enableAreaClearanceOperation = CamData.Operations.AreaClearanceEnable;
    ((PanelCutTempVars) CamProfileData).enableFinishOperation = CamData.Operations.FinishEnable;
    ((PanelCutMoveCommand) CamProfileData).enableOpenContourTwoDirectionCutOperation = CamData.Strategy.OpenContourTwoDirectionCut;
  }
}
