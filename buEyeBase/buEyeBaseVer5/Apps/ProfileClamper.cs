// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileClamper
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileClamper : buSerilization5
{
  public double SheetEntityThickness;
  public double SheetInnerThickness;
  public int GridPartSheetHeight;
  public int GridPartSheetPreviewWidth;
  public bool ShowSheetFileNameColumb;
  public bool ShowSheetItemNoColumb;
  public bool ShowSheetThicknessColumb;
  public bool ShowSheetOtherColumb;
  public bool ShowSheetAuxColumb;
  public bool ShowPartFileNameColumb;
  public bool ShowPartItemNoColumb;

  public int GetSelectedOperationCount(ProfileItem curItem)
  {
    int selectedOperationCount = 0;
    for (int index = 0; index <= ((ProfileSettings) curItem).Operations.Count - 1; ++index)
    {
      if (((ProfileRuntimeSettings) ((ProfileSettings) curItem).Operations[index]).Selected)
        ++selectedOperationCount;
    }
    return selectedOperationCount;
  }

  public void ShapeFromProfileOperation(ProfileOperation OP, ref buShape Shape)
  {
    ProfileOperationData operationData = ((ProfileRuntimeSettings) OP).OperationData;
    if (((CreateProfileFromDataOptions) operationData).OperationType == ProfileOperationTypes.Rectangle)
      Shape = (buShape) new buUpperLineEnt(((CreateProfileFromDataOptions) ((DepthPositions) operationData).RectangleData).RectangleWidth, ((OperationUpdateArg) ((DepthPositions) operationData).RectangleData).RectangleHeight, ((OperationUpdateArg) ((DepthPositions) operationData).RectangleData).RectangleRadius, 0.0, ((ProfileRuntimeSettings) OP).Depth, ((OperationUpdateArg) ((DepthPositions) operationData).RectangleData).RectangleAngle);
    else if (((CreateProfileFromDataOptions) operationData).OperationType == ProfileOperationTypes.Circle)
      Shape = (buShape) new buUpperLineEnt(((CreateProfileFromDataOptions) ((OperationInsideClampers) operationData).CircleData).CircleDiameter / 2.0, ((ProfileRuntimeSettings) OP).Depth);
    else if (((CreateProfileFromDataOptions) operationData).OperationType == ProfileOperationTypes.Ellipse)
      Shape = (buShape) new buUpperLineEnt(((NestingPanelJob) ((DepthPositions) operationData).EllipseData).EllipseWidth / 2.0, ((NestingPanelJob) ((DepthPositions) operationData).EllipseData).EllipseHeight / 2.0, ((ProfileRuntimeSettings) OP).Depth, ((NestingPanelJob) ((DepthPositions) operationData).EllipseData).EllipseAngle);
    else if (((CreateProfileFromDataOptions) operationData).OperationType == ProfileOperationTypes.Barrel)
      Shape = (buShape) new buLinearPathArrow(((PanelCutMove) ((DepthPositions) operationData).BarelData).BarrelDiameter, ((PanelCutMove) ((DepthPositions) operationData).BarelData).BarrelWidth, ((PanelCutMove) ((DepthPositions) operationData).BarelData).BarrelLength, ((ProfileRuntimeSettings) OP).Depth, ((PanelCutMove) ((DepthPositions) operationData).BarelData).BarrelAngle);
    else if (((CreateProfileFromDataOptions) operationData).OperationType == ProfileOperationTypes.Polygon)
      Shape = (buShape) new buUpperLineEnt(((CreateProfileFromDataOptions) ((DepthPositionOptions) operationData).PolygonData).PolygonDiameter / 2.0, ((CreateProfileFromDataOptions) ((DepthPositionOptions) operationData).PolygonData).PolygonSide, ((ProfileRuntimeSettings) OP).Depth, ((CreateProfileFromDataOptions) ((DepthPositionOptions) operationData).PolygonData).PolygonAngle);
    else if (((CreateProfileFromDataOptions) operationData).OperationType == ProfileOperationTypes.Slot)
      Shape = (buShape) new buUpperLineEnt(((PanelEntityData) ((DepthPositions) operationData).SlotData).SlotDiameter, ((PanelEntityData) ((DepthPositions) operationData).SlotData).SlotWidth, ((ProfileRuntimeSettings) OP).Depth, ((PanelEntityData) ((DepthPositions) operationData).SlotData).SlotAngle);
    else if (((CreateProfileFromDataOptions) operationData).OperationType == ProfileOperationTypes.Cut)
      Shape = (buShape) new buSelectionPoint(CutTypes.CutVertical, ((PanelDonePart) ((DepthPositions) operationData).CutData).CutHeigth, ((ProfileRuntimeSettings) OP).Depth, ((PanelDonePart) ((DepthPositions) operationData).CutData).CutWidth);
    else if (((CreateProfileFromDataOptions) operationData).OperationType == ProfileOperationTypes.FreeDraw)
      Shape = (buShape) new buLinearPathArrow(((NestingPanelNode) ((DepthPositionOptions) operationData).FreeDrawData).FreeDrawWidth, ((NestingPanelNode) ((DepthPositionOptions) operationData).FreeDrawData).FreeDrawHeight, ((ProfileRuntimeSettings) OP).Depth, ((NestingPanelNode) ((DepthPositionOptions) operationData).FreeDrawData).FreeDrawAngle);
    else if (((CreateProfileFromDataOptions) operationData).OperationType == ProfileOperationTypes.Text)
    {
      Shape = (buShape) new buMaterial(((NestingPanelNode) ((DepthPositionOptions) operationData).TextData).TextWidth, ((NestingPanelNode) ((DepthPositionOptions) operationData).TextData).TextHeight, ((ProfileRuntimeSettings) OP).Depth, ((NestingPanelNode) ((DepthPositionOptions) operationData).TextData).TextString, ((NestingPanelNode) ((DepthPositionOptions) operationData).TextData).TextFont, ((NestingPanelNode) ((DepthPositionOptions) operationData).TextData).TextAngle);
      ((CutterProgramSettings) Shape).isWire = ((NestingPanelNode) ((DepthPositionOptions) operationData).TextData).isWire;
    }
    ((\u0012.\u0002) Shape).Priority = ((ProfileRuntimeSettings) OP).Priority;
    ((buClipper) Shape).BasePoint = new Point3D(((ProfileOnlineOpOptions) operationData).basePosition.X, ((ProfileOnlineOpOptions) operationData).basePosition.Y, ((ProfileOnlineOpOptions) operationData).basePosition.Z);
    ((buClipperBase) Shape).planeName = buNumeric5.PlaneNamesToPlaneBoxNames(((ProfileMirror) operationData).selectedPlaneName);
    ((buClipper) Shape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) Shape).planeName);
    ((buClipperBase) Shape).Corner = ((CreateProfileFromDataOptions) operationData).Corner;
    ((buClipperBase) Shape).Alignment = ((CreateProfileFromDataOptions) operationData).Alignment;
    ((\u0012.\u0002) Shape).DepthExtra = ((ProfileArray) operationData).ExtraDepth;
    ((buClipper) Shape).CamPar = (camParameters5) new camRuntime5(((ProfileArray) operationData).CamParMilling);
    ((buClipperBase) Shape).isPocket = ((ProfileArray) operationData).CamParMilling.Operations.AreaClearanceEnable;
  }

  public void CheckOperationSpeeds(ref ProfileOperation OP)
  {
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Notch)
      return;
    if (((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).CamParMilling.Speeds).SpindleSpeed == 0.0)
      ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).CamParMilling.Speeds).SpindleSpeed = ((ToolPositions5) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).CamData).SpindleSpeed;
    if (((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).CamParMilling.Speeds.Feed == 0.0)
    {
      if (((PanelCutSettings) ((ProfileRuntimeSettings) OP).CamOPData).velFeed > 0.0)
        ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).CamParMilling.Speeds.Feed = ((PanelCutSettings) ((ProfileRuntimeSettings) OP).CamOPData).velFeed;
      else
        ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).CamParMilling.Speeds.Feed = ((ToolLimits5) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).CamData).FeedSpeed;
    }
    if (((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).CamParMilling.Speeds.Plunge == 0.0)
    {
      if (((PanelCutSettings) ((ProfileRuntimeSettings) OP).CamOPData).velPlunge > 0.0)
        ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).CamParMilling.Speeds.Plunge = ((PanelCutSettings) ((ProfileRuntimeSettings) OP).CamOPData).velPlunge;
      else
        ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).CamParMilling.Speeds.Plunge = ((ToolPositions5) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).CamData).PlungeSpeed;
    }
    if (((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).CamParMilling.Speeds).Finish == 0.0)
    {
      if (((PanelCutSettings) ((ProfileRuntimeSettings) OP).CamOPData).velFinish > 0.0)
        ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).CamParMilling.Speeds).Finish = ((PanelCutSettings) ((ProfileRuntimeSettings) OP).CamOPData).velFinish;
      else
        ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).CamParMilling.Speeds).Finish = ((ToolLimits5) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).CamData).FinishSpeed;
    }
    if (((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).CamParMilling.Speeds).Leave != 0.0)
      return;
    if (((PanelCutRuntimeSettings) ((ProfileRuntimeSettings) OP).CamOPData).velLeave > 0.0)
      ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).CamParMilling.Speeds).Leave = ((PanelCutRuntimeSettings) ((ProfileRuntimeSettings) OP).CamOPData).velLeave;
    else
      ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).CamParMilling.Speeds).Leave = ((ToolPositions5) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).CamData).LeaveSpeed;
  }

  public void AddOperationToProfileOperationList(
    ref ProfileItem Item,
    ProfileOperation OP,
    bool AddSmallSizeBeforeIfSamePos)
  {
    if (Item == null)
      return;
    if (((ProfileSettings) Item).Operations.Count == 0)
    {
      ((ProfileSettings) Item).Operations.Add(OP);
    }
    else
    {
      bool flag = false;
      if (AddSmallSizeBeforeIfSamePos)
      {
        for (int index = 0; index <= ((ProfileSettings) Item).Operations.Count - 1; ++index)
        {
          // ISSUE: reference to a compiler-generated method
          if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) ((ProfileSettings) Item).Operations[index]).OperationData).OperationType & !flag && ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == ((ProfileMirror) ((ProfileRuntimeSettings) ((ProfileSettings) Item).Operations[index]).OperationData).selectedPlaneName && buConversion5.\u003C\u003Ec.EQ(((ProfilePatternCopy) ((ProfileRuntimeSettings) OP).OperationData).Position, ((ProfilePatternCopy) ((ProfileRuntimeSettings) ((ProfileSettings) Item).Operations[index]).OperationData).Position, 0.01) && ((ProfileRuntimeSettings) OP).MaxPoint.X - ((ProfileRuntimeSettings) OP).MinPoint.X < ((ProfileRuntimeSettings) ((ProfileSettings) Item).Operations[index]).MaxPoint.X - ((ProfileRuntimeSettings) ((ProfileSettings) Item).Operations[index]).MinPoint.X)
          {
            ((ProfileSettings) Item).Operations.Insert(index, OP);
            flag = true;
          }
        }
      }
      if (flag)
        return;
      ((ProfileSettings) Item).Operations.Add(OP);
    }
  }

  public void FindOperationFromCalculatedOperationsByID(
    ProfileItem Item,
    string ID,
    ref ProfileOperation foundOP)
  {
    if (Item == null)
      return;
    for (int index = 0; index <= ((ProfileSettings) Item).Operations.Count - 1; ++index)
    {
      if (((ProfileRuntimeSettings) ((ProfileSettings) Item).Operations[index]).ID == ID)
      {
        foundOP = ((ProfileSettings) Item).Operations[index];
        break;
      }
    }
  }

  public void ShapeRunTimeToOperationData(
    ShapeRuntimeData shapeRuntimeData,
    ref ProfileOperationData OPData)
  {
    if (shapeRuntimeData.ShapeType == ShapeTypes.Rectangle)
    {
      ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleHeight = ((CurveToSurfaceSettingsType) shapeRuntimeData).RectangleHeight;
      ((CreateProfileFromDataOptions) ((DepthPositions) OPData).RectangleData).RectangleWidth = ((CurveToSurfaceSettingsType) shapeRuntimeData).RectangleWidth;
      ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleRadius = ((SelectedPlaneInfo) shapeRuntimeData).RectangleRadius;
      ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleChamfer = ((SelectedPlaneInfo) shapeRuntimeData).RectangleChamfer;
    }
    ((ProfileArray) OPData).ExtraDepth = ((CurveToSurfaceSettingsType) shapeRuntimeData).ExtraDepth;
  }

  public void OperationDataToShapeRunTime(
    ProfileOperationData OPData,
    ref ShapeRuntimeData shapeRuntimeData)
  {
    ((CurveToSurfaceSettingsType) shapeRuntimeData).RectangleHeight = ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleHeight;
    ((SelectedPlaneInfo) shapeRuntimeData).RectangleAngle = ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleAngle;
    ((ShapeRuntimeData) shapeRuntimeData.Edit).RotateDegree = ((SelectedPlaneInfo) shapeRuntimeData).RectangleAngle;
    ((CurveToSurfaceSettingsType) shapeRuntimeData).RectangleWidth = ((CreateProfileFromDataOptions) ((DepthPositions) OPData).RectangleData).RectangleWidth;
    ((SelectedPlaneInfo) shapeRuntimeData).RectangleRadius = ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleRadius;
    ((SelectedPlaneInfo) shapeRuntimeData).RectangleChamfer = ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleChamfer;
    if (((CreateProfileFromDataOptions) OPData).OperationType == ProfileOperationTypes.Rectangle)
    {
      ((SelectedPlaneInfo) shapeRuntimeData).RectangleDepth = ((ProfileArray) OPData).ExternalDepth;
      ((ShapeRuntimeData) shapeRuntimeData.Edit).RotateDegree = ((SelectedPlaneInfo) shapeRuntimeData).RectangleAngle;
    }
    ((SelectionEntityTypes) shapeRuntimeData).SlotAngle = ((PanelEntityData) ((DepthPositions) OPData).SlotData).SlotAngle;
    ((SelectionEntityTypes) shapeRuntimeData).SlotDiameter = ((PanelEntityData) ((DepthPositions) OPData).SlotData).SlotDiameter;
    ((SelectedPlaneInfo) shapeRuntimeData).SlotLength = ((PanelEntityData) ((DepthPositions) OPData).SlotData).SlotWidth;
    if (((CreateProfileFromDataOptions) OPData).OperationType == ProfileOperationTypes.Slot)
    {
      ((SelectionEntityTypes) shapeRuntimeData).SlotDepth = ((ProfileArray) OPData).ExternalDepth;
      ((ShapeRuntimeData) shapeRuntimeData.Edit).RotateDegree = ((SelectionEntityTypes) shapeRuntimeData).SlotAngle;
    }
    ((SelectedPlaneInfo) shapeRuntimeData).PolygonAngle = ((CreateProfileFromDataOptions) ((DepthPositionOptions) OPData).PolygonData).PolygonAngle;
    ((SelectedPlaneInfo) shapeRuntimeData).PolygonRadius = ((CreateProfileFromDataOptions) ((DepthPositionOptions) OPData).PolygonData).PolygonDiameter / 2.0;
    ((SelectedPlaneInfo) shapeRuntimeData).PolygonSide = ((CreateProfileFromDataOptions) ((DepthPositionOptions) OPData).PolygonData).PolygonSide;
    if (((CreateProfileFromDataOptions) OPData).OperationType == ProfileOperationTypes.Polygon)
    {
      ((SelectedPlaneInfo) shapeRuntimeData).PolygonDepth = ((ProfileArray) OPData).ExternalDepth;
      ((ShapeRuntimeData) shapeRuntimeData.Edit).RotateDegree = ((SelectedPlaneInfo) shapeRuntimeData).PolygonAngle;
    }
    ((SelectionOperation) shapeRuntimeData).KeyHoleAngle = ((PanelCutMove) ((DepthPositions) OPData).BarelData).BarrelAngle;
    ((SelectionEntityTypes) shapeRuntimeData).KeyHoleDiameter = ((PanelCutMove) ((DepthPositions) OPData).BarelData).BarrelWidth;
    ((SelectionEntityTypes) shapeRuntimeData).KeyHoleHeadDiameter = ((PanelCutMove) ((DepthPositions) OPData).BarelData).BarrelDiameter;
    ((SelectionEntityTypes) shapeRuntimeData).KeyHoleLength = ((PanelCutMove) ((DepthPositions) OPData).BarelData).BarrelLength;
    if (((CreateProfileFromDataOptions) OPData).OperationType == ProfileOperationTypes.Barrel)
    {
      ((SelectionOperation) shapeRuntimeData).KeyHoleDepth = ((ProfileArray) OPData).ExternalDepth;
      ((ShapeRuntimeData) shapeRuntimeData.Edit).RotateDegree = ((SelectionOperation) shapeRuntimeData).KeyHoleAngle;
    }
    ((SelectionEntity) shapeRuntimeData).HoleDiameter = ((NestingPanel) ((DepthPositions) OPData).HoleData).HoleDiameter;
    if (((CreateProfileFromDataOptions) OPData).OperationType == ProfileOperationTypes.Hole)
      ((SelectionEntity) shapeRuntimeData).HoleDepth = ((ProfileArray) OPData).ExternalDepth;
    ((SelectedPlaneInfo) shapeRuntimeData).EllipseAngle = ((NestingPanelJob) ((DepthPositions) OPData).EllipseData).EllipseAngle;
    ((SelectedPlaneInfo) shapeRuntimeData).EllipseRadiusX = ((NestingPanelJob) ((DepthPositions) OPData).EllipseData).EllipseWidth / 2.0;
    ((SelectedPlaneInfo) shapeRuntimeData).EllipseRadiusY = ((NestingPanelJob) ((DepthPositions) OPData).EllipseData).EllipseHeight / 2.0;
    if (((CreateProfileFromDataOptions) OPData).OperationType == ProfileOperationTypes.Ellipse)
    {
      ((SelectedPlaneInfo) shapeRuntimeData).EllipseDepth = ((ProfileArray) OPData).ExternalDepth;
      ((ShapeRuntimeData) shapeRuntimeData.Edit).RotateDegree = ((SelectedPlaneInfo) shapeRuntimeData).EllipseAngle;
    }
    ((SelectedPlaneInfo) shapeRuntimeData).CircleRadius = ((CreateProfileFromDataOptions) ((OperationInsideClampers) OPData).CircleData).CircleDiameter / 2.0;
    if (((CreateProfileFromDataOptions) OPData).OperationType == ProfileOperationTypes.Circle)
      ((SelectedPlaneInfo) shapeRuntimeData).CircleDepth = ((ProfileArray) OPData).ExternalDepth;
    ((ShapeRuntimeData) shapeRuntimeData.Edit).ArrayData = (ShapeArray) new GCodeConverter(((DepthPositionOptions) OPData).Array);
    ((ShapeRuntimeData) shapeRuntimeData.Edit).MirrorData = (ShapeMirror) new GCodePoint5(((DepthPositionOptions) OPData).Mirror);
    ((SelectionEntity) shapeRuntimeData).FreeDrawAngle = ((NestingPanelNode) ((DepthPositionOptions) OPData).FreeDrawData).FreeDrawAngle;
    ((SelectionOperation) shapeRuntimeData).FreeDrawWidth = ((NestingPanelNode) ((DepthPositionOptions) OPData).FreeDrawData).FreeDrawWidth;
    ((SelectionOperation) shapeRuntimeData).FreeDrawHeight = ((NestingPanelNode) ((DepthPositionOptions) OPData).FreeDrawData).FreeDrawHeight;
    if (((CreateProfileFromDataOptions) OPData).OperationType == ProfileOperationTypes.FreeDraw)
    {
      ((SelectionOperation) shapeRuntimeData).FreeDrawDepth = ((ProfileArray) OPData).ExternalDepth;
      ((ShapeRuntimeData) shapeRuntimeData.Edit).RotateDegree = ((SelectionEntity) shapeRuntimeData).FreeDrawAngle;
    }
    ((SelectionEntity) shapeRuntimeData).TextAngle = ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).TextAngle;
    ((SelectionEntity) shapeRuntimeData).TextHeight = ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).TextHeight;
    ((SelectionEntity) shapeRuntimeData).TextWidth = ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).TextWidth;
    ((SelectionEntity) shapeRuntimeData).TextString = ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).TextString;
    ((SelectionEntity) shapeRuntimeData).TextFont = ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).TextFont;
    if (((CreateProfileFromDataOptions) OPData).OperationType == ProfileOperationTypes.Text)
    {
      ((SelectionEntity) shapeRuntimeData).TextDepth = ((ProfileArray) OPData).ExternalDepth;
      ((ShapeRuntimeData) shapeRuntimeData.Edit).RotateDegree = ((SelectionEntity) shapeRuntimeData).TextAngle;
    }
    ((dynamicInfo) shapeRuntimeData).NotchSideLocation = ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchLocation;
    ((dynamicInfo) shapeRuntimeData).NotchOPType = ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchOPType;
    ((MachineConfigSettings) shapeRuntimeData).NotchDepth = ((NestingPanelJob) ((DepthPositions) OPData).NotchData).NotchDepth;
    ((CustomDataAdd) shapeRuntimeData).NotchHeight = ((NestingPanelJob) ((DepthPositions) OPData).NotchData).NotchHeight;
    ((dynamicInfo) shapeRuntimeData).NotchFrontBack = ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchFrontBack;
    ((MachineConfigSettings) shapeRuntimeData).NotchStartHeight = ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchStart;
    ((dynamicInfo) shapeRuntimeData).NotchUpDown = ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchUpDown;
    ((CustomDataAdd) shapeRuntimeData).NotchWidth = ((NestingPanelJob) ((DepthPositions) OPData).NotchData).NotchWidth;
    shapeRuntimeData.selectedPlane = buNumeric5.PlaneNamesToPlaneBoxNames(((ProfileMirror) OPData).selectedPlaneName);
    shapeRuntimeData.pntBase = F_NotchEdit.ToPoint3D(((ProfileOnlineOpOptions) OPData).basePosition);
    shapeRuntimeData.pntBase.X = ((ProfileOnlineOpOptions) OPData).basePosition.X;
    shapeRuntimeData.selectedCorner = ((CreateProfileFromDataOptions) OPData).Corner;
    shapeRuntimeData.objectAlignment = ((CreateProfileFromDataOptions) OPData).Alignment;
    shapeRuntimeData.isShapePocket = ((ProfileArray) OPData).CamParMilling.Operations.AreaClearanceEnable;
    ((ShapeTempData) shapeRuntimeData).EachLayer = ((ProfileMirror) OPData).EachLayer;
    ((CurveToSurfaceSettingsType) shapeRuntimeData).ExtraDepth = ((ProfileArray) OPData).ExtraDepth;
    ((CurveToSurfaceSettingsType) shapeRuntimeData).ManuelDepthStart = ((ProfileArray) OPData).ManuelZVal;
    ((ShapeTempData) shapeRuntimeData).ManuelDepthEnable = ((ProfileMirror) OPData).ManuelZEnable;
    shapeRuntimeData.CamPars = (camParameters5) new camRuntime5(((ProfileArray) OPData).CamParMilling);
  }

  public void SplitOperationByToolNo(
    List<GProfileOperation> refOperations,
    ref List<List<GProfileOperation>> splitedOP)
  {
    if (refOperations.Count <= 0)
      return;
    splitedOP = new List<List<GProfileOperation>>();
    splitedOP.Add(new List<GProfileOperation>()
    {
      (GProfileOperation) new buMarbleCalc(refOperations[0])
    });
    List<GProfileOperation> gprofileOperationList = new List<GProfileOperation>();
    for (int index1 = 1; index1 <= refOperations.Count - 1; ++index1)
    {
      bool flag = false;
      GProfileOperation gprofileOperation = (GProfileOperation) new buMarbleCalc(refOperations[index1]);
      for (int index2 = 0; index2 <= splitedOP.Count - 1; ++index2)
      {
        for (int index3 = 0; index3 <= splitedOP[index2].Count - 1; ++index3)
        {
          if (((ToolCamData5) ((ToolGeometry5) ((ProfileRuntimeSettings) splitedOP[index2][index3]).Tool).Data).No == ((ToolCamData5) ((ToolGeometry5) ((ProfileRuntimeSettings) gprofileOperation).Tool).Data).No & !flag)
          {
            splitedOP[index2].Add(gprofileOperation);
            flag = true;
          }
        }
      }
      if (!flag)
        splitedOP.Add(new List<GProfileOperation>()
        {
          gprofileOperation
        });
    }
  }

  public void SplitOperationByPlane(
    List<GProfileOperation> refOperations,
    ref List<List<GProfileOperation>> splitedOP)
  {
    if (refOperations.Count <= 0)
      return;
    splitedOP = new List<List<GProfileOperation>>();
    List<GProfileOperation> gprofileOperationList1 = new List<GProfileOperation>();
    List<GProfileOperation> gprofileOperationList2 = new List<GProfileOperation>();
    List<GProfileOperation> gprofileOperationList3 = new List<GProfileOperation>();
    List<GProfileOperation> gprofileOperationList4 = new List<GProfileOperation>();
    List<GProfileOperation> gprofileOperationList5 = new List<GProfileOperation>();
    for (int index = 0; index <= refOperations.Count - 1; ++index)
    {
      if (((ProfileMirror) ((ProfileRuntimeSettings) refOperations[index]).OperationData).selectedPlaneName == planeNames.Top)
        gprofileOperationList1.Add((GProfileOperation) new buMarbleCalc(refOperations[index]));
      if (((ProfileMirror) ((ProfileRuntimeSettings) refOperations[index]).OperationData).selectedPlaneName == planeNames.Front)
        gprofileOperationList2.Add((GProfileOperation) new buMarbleCalc(refOperations[index]));
      if (((ProfileMirror) ((ProfileRuntimeSettings) refOperations[index]).OperationData).selectedPlaneName == planeNames.Back)
        gprofileOperationList3.Add((GProfileOperation) new buMarbleCalc(refOperations[index]));
      if (((ProfileMirror) ((ProfileRuntimeSettings) refOperations[index]).OperationData).selectedPlaneName == planeNames.Free)
        gprofileOperationList4.Add((GProfileOperation) new buMarbleCalc(refOperations[index]));
      if (((ProfileMirror) ((ProfileRuntimeSettings) refOperations[index]).OperationData).selectedPlaneName == planeNames.Bottom)
        gprofileOperationList5.Add((GProfileOperation) new buMarbleCalc(refOperations[index]));
    }
    if (gprofileOperationList1.Count > 0)
      splitedOP.Add(gprofileOperationList1);
    if (gprofileOperationList3.Count > 0)
      splitedOP.Add(gprofileOperationList3);
    if (gprofileOperationList2.Count > 0)
      splitedOP.Add(gprofileOperationList2);
    if (gprofileOperationList4.Count > 0)
      splitedOP.Add(gprofileOperationList4);
    if (gprofileOperationList5.Count <= 0)
      return;
    splitedOP.Add(gprofileOperationList5);
  }
}
