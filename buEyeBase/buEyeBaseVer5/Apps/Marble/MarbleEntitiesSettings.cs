// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleEntitiesSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleEntitiesSettings : buSerilization5
{
  public static MarbleDisplaySettings varMarbleDisplaySettings;
  public static MarbleColorSettings varMarbleColorSettings;
  public static MarbleControlColorSettings varMarbleControlColorSettings;
  public static MarbleEntitiesSettings varMarbleEntitiesSettings;
  public static MarbleDrawingSetting varMarbleDrawSettings;
  public static MarbleImageSettings varImageSettings;
  public static MarbleCountertopSettings varCountertopSettings;
  public static marbleCounterTopParameter varCountertopParameter;
  public static List<GeometryTableItem> CircularShapeResolutions;
  public static List<CircularSpeedReduction> CircularSpeedReductions;
  public static marbleCounterTopPars runCountertopData;

  public abstract void m001E97();

  public MarbleEntitiesSettings()
  {
    ((MarbleItem) this).AutoToolFind = false;
    ((MarbleItem) this).ShowProgressCam = true;
    ((MarbleItem) this).MeasureActive = false;
    ((MarbleItem) this).DrawMouseDown = false;
    ((MarbleItem) this).lastShape = (buShape) null;
    ((MarbleItem) this).pntMouseDown = (Point3D) null;
    ((MarbleItem) this).ViewportRef = ViewportRefType.Editor;
    ((MarbleItem) this).activePlane = planeBoxNames.Top;
    ((MarbleItem) this).JobItemType = ProfileJobType.Left;
    ((MarbleItem) this).selectedProfileIndex = -1;
    ((MarbleItem) this).selectedItemIndex = -1;
    ((MarbleItemCam) this).LastGCodeLine = 10;
    ((MarbleItemCam) this).Macros = new List<MacroItem>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MarbleEntitiesSettings(ProfileTempVars data)
  {
    ((MarbleItem) this).AutoToolFind = false;
    ((MarbleItem) this).ShowProgressCam = true;
    ((MarbleItem) this).MeasureActive = false;
    ((MarbleItem) this).DrawMouseDown = false;
    ((MarbleItem) this).lastShape = (buShape) null;
    ((MarbleItem) this).pntMouseDown = (Point3D) null;
    ((MarbleItem) this).ViewportRef = ViewportRefType.Editor;
    ((MarbleItem) this).activePlane = planeBoxNames.Top;
    ((MarbleItem) this).JobItemType = ProfileJobType.Left;
    ((MarbleItem) this).selectedProfileIndex = -1;
    ((MarbleItem) this).selectedItemIndex = -1;
    ((MarbleItemCam) this).LastGCodeLine = 10;
    ((MarbleItemCam) this).Macros = new List<MacroItem>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
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

  static MarbleEntitiesSettings()
  {
    MarbleJob.strRectangle = "Rectangle";
    MarbleJob.strCircle = "Circle";
    MarbleJob.strEllipse = "Ellipse";
    MarbleJob.strHole = "Hole";
    MarbleJob.strKeyHole = "Key Hole";
    MarbleItem.strRoundRect = "Round Rect";
    MarbleItem.strSlot = "Slot";
    MarbleItem.strNotch = "Notch";
    MarbleItem.strFreeDraw = "Free";
    MarbleItem.strText = "Text";
    MarbleItem.strCut = "Cut";
    MarbleItem.strPoylgon = "Polygon";
    MarbleItem.LayerNameProfile = "Profile";
    MarbleItem.LayerNameOperation = "Operation";
    MarbleItem.LayerNameCam = "Cam";
    MarbleItem.LayerNameContour = "Contour";
    MarbleItem.LastCreatedProfileEntityName = "";
    MarbleItem.LastCreatedProfileEntityIndex = -1;
    MarbleItem.OperationEditing = false;
    MarbleItem.MultiOperationStarted = false;
    MarbleItem.ClamperMoved = false;
    MarbleItem.TemplateXOffset = 0.0;
    MarbleItem.TemplateScaleUseX = false;
    MarbleItem.TemplateScaleUseYZ = false;
    MarbleItem.TemplateXScaleRatio = 1.0;
    MarbleItem.TemplateYZScaleRatio = 1.0;
    MarbleItem.MainBottomTabIndex = 0;
    MarbleItem.PlaneIncrement = 1.0;
    MarbleItem.PlaneSelectedIndex = -1;
    MarbleItem.PlaneInited = false;
    MarbleItem.DepthInited = false;
    MarbleItem.TemplateMode = false;
    MarbleItem.CamAssinged = false;
    MarbleItem.DepthForced = false;
    MarbleItem.DepthSelectedIndex = -1;
    MarbleItem.RotateKeyKole = false;
    MarbleItem.ChangeCamDir = false;
    MarbleItem.P6SimMachine = (Pnt6DSimMove) new AlingmentPoints3D();
    MarbleItem.P6SimTool = new Pnt6D();
    MarbleItem.P3SimTool = new Point3D();
    MarbleItem.PntPatternDxf = new Point3D();
    MarbleItem.PAngleSimTool = new OrientationAngle();
    MarbleItem.PatternDxfOperation = false;
    MarbleItem.CreatingOperation = (buEyeBaseVer5.Apps.ProfileOperation) null;
    MarbleItemCam.DontMoveClamperForPark = false;
    MarbleItemCam.MultiSelectedProps = new ProfileMultiSelectedOperation();
    MarbleItemCam.SelectedOperations = new List<buEyeBaseVer5.Apps.ProfileOperation>();
    MarbleItemCam.OperationDepths = new List<DepthPositions>();
    MarbleItemCam.LastClampers = new List<buEyeBaseVer5.Apps.ProfileClamper>();
  }

  public MarbleEntitiesSettings()
  {
    ((MarbleItemCam) this).MaterialTranspancy = 250;
    ((MarbleItemCam) this).EachLayerSafeDistance = 1.0;
    ((MarbleItemCam) this).EachLayerMinThickness = 0.2;
    ((MarbleItemCam) this).EachLayerMaxThickness = 1200.0;
    ((MarbleItemCam) this).EachLayerFromArea = true;
    ((MarbleItemCam) this).EachLayerAreaDevideCount = 10;
    ((MarbleItemCam) this).EachLayerConnectGap = 0.5;
    ((MarbleItemCam) this).ProfileMaxClamper = 4;
    ((MarbleItemCam) this).SupportBlockZColor = Color.Yellow;
    ((MarbleItemCam) this).ProfileColor = Color.DarkGray;
    ((MarbleItemCam) this).FindToolAuto = true;
    ((MarbleItemCam) this).FindToolAutoFromDepth = true;
    ((MarbleItemCam) this).MinXMove = 100.0;
    ((MarbleItemCam) this).MinYMove = -2000.0;
    ((MarbleItemCam) this).MinZMove = -1000.0;
    ((MarbleItemCam) this).MinAMove = -90.0;
    ((MarbleItemCam) this).MaxXMove = 10000.0;
    ((MarbleItemCam) this).MaxYMove = 2000.0;
    ((MarbleItemCam) this).MaxZMove = 1000.0;
    ((MarbleItemCam) this).MaxAMove = 90.0;
    ((MarbleItemCam) this).ShowToolChangeInSimulation = true;
    ((MarbleItemCam) this).ToolChangeX = 0.0;
    ((MarbleItemCam) this).ToolChangeY = 0.0;
    ((MarbleItemCam) this).ToolChangeZ = 200.0;
    ((MarbleItemCam) this).ToolChangeA = 0.0;
    ((MarbleItemCam) this).MachineLength = 3200.0;
    ((MarbleItemCam) this).CutQuality = 0.05;
    ((MarbleItemCam) this).ConnectSmallGap = true;
    ((MarbleItemCam) this).GapConnectionForProfile = 0.02;
    ((MarbleItemCam) this).ProfileSortResolution = 0.05;
    ((MarbleItemCam) this).MinProfileFilterLength = 0.0;
    ((MarbleItemCam) this).IntersectionRules = SortingIntersectionRulesType.LowerIndex;
    ((MarbleItemCam) this).ProfileSizeExceedDepthLimit = 5.0;
    ((MarbleItemCam) this).CalculateClamperEveryTime = false;
    ((MarbleVacuumCut) this).ManuelClamperSet = false;
    ((MarbleVacuumCut) this).NoClampedOutput = false;
    ((MarbleVacuumCut) this).ParkPositionX = 100.0;
    ((MarbleVacuumCut) this).ParkPositionY = 0.0;
    ((MarbleVacuumCut) this).ParkPositionZ = 250.0;
    ((MarbleVacuumCut) this).ToolHolderLength = 73.0;
    ((MarbleVacuumCut) this).ToolPensDiameter = 63.0;
    ((MarbleVacuumCut) this).FirstPositionOffset = 100.0;
    ((MarbleVacuumCut) this).GoFirstPosition = true;
    ((MarbleVacuumCut) this).AutoOpenLastLoadedProfile = true;
    ((MarbleVacuumCut) this).AutoOpenLastLoadedProfileAndOperations = true;
    ((MarbleVacuumCut) this).SaveCurrentProfilesWhileProgramClosing = false;
    ((MarbleItemSettings) this).ToolSpeedDataToOperationSpeedData = true;
    ((MarbleItemSettings) this).ToolDistanceDataToOperationDistanceData = true;
    ((MarbleItemSettings) this).AutoCloseWater = false;
    ((MarbleItemSettings) this).DontAddLineFromExternalFile = true;
    ((MarbleItemSettings) this).ClamperCanMoveInsideProfileLength = true;
    ((MarbleItemSettings) this).MultipleEdit = false;
    ((MarbleItemSettings) this).ProfilePositionCalculation = ProfilePositionCalculationMode.ToolTipPoint;
    ((MarbleItemSettings) this).ProfileSafeDistanceForPlanes = ProfileSafeDistanceMode.G53Mode;
    ((MarbleItemSettings) this).ProfileOutsizeClamperMode = ProfileOutSizeClamperMode.Offset;
    ((MarbleItemSettings) this).OperationWindow = ProfileOperationWindowType.AutoHideDock;
    ((MarbleItemSettings) this).OperationWindowClose = ProfileOperationWindowCloseType.Hide;
    ((MarbleItemSettings) this).GoFirstPositionMode = GoFirstPositionType.ParkPosition;
    ((MarbleItemSettings) this).FindToolType = ToolFindType.MostSmall;
    ((MarbleItemSettings) this).YDirection = ProfileYAxisDirection.NegativeDirection;
    ((MarbleItemSettings) this).XDirection = ProfileXAxisDirection.Left;
    ((MarbleItemSettings) this).XDirRefType = LeftRightType.Left;
    ((MarbleItemSettings) this).ShowCabinet = false;
    ((MarbleItemSettings) this).PreviewViewType = buViewTypeBasic.Right;
    ((MarbleItemSettings) this).ShowPreviewSides = true;
    ((MarbleItemSettings) this).ShowOperationButton = true;
    ((MarbleItemSettings) this).PreviewSideColor = Color.Green;
    ((MarbleItemSettings) this).PreviewDoneOperationColor = Color.Orange;
    ((MarbleItemSettings) this).PreviewActiveOperationColor = Color.Cyan;
    ((MarbleItemEntities) this).GhostClamperColor = Color.LightPink;
    ((MarbleItemEntities) this).GhostClamperTransparency = 100;
    ((MarbleItemEntities) this).NotchToolNo = 4;
    ((MarbleItemEntities) this).NotchMinSpeed = 100.0;
    ((MarbleItemEntities) this).NotchMaxSpeed = 5000.0;
    ((MarbleItemEntities) this).MillingToolMaxSpeed = 30000.0;
    ((MarbleItemEntities) this).ProfileMaxLength = 10000.0;
    ((MarbleItemEntities) this).ProfileMaxWidth = 1000.0;
    ((MarbleItemEntities) this).ProfileMaxHeight = 1000.0;
    ((MarbleItemEntities) this).PlaneMoveSafeDistance = 20.0;
    ((MarbleItemEntities) this).ProfileAddWidthHeightReadOnly = false;
    ((MarbleItemEntities) this).ChangeAAxisWhileMoveBetweenPlanes = false;
    ((MarbleItemEntities) this).TopOperationClamperMoveZValue = 130.0;
    ((MarbleItemEntities) this).AutoPeckingAddDefault = false;
    ((MarbleItemEntities) this).AutoPeckingUpDefaultDistance = 0.0;
    ((MarbleItemEntities) this).RightProfileMakeAsMirror = true;
    ((MarbleItemEntities) this).AllGCodeAsG1 = false;
    ((MarbleItemEntities) this).UseUndoBuffer = false;
    ((MarbleItemEntities) this).OperationFrontBackMirrorYDirToAnotherPlane = false;
    ((MarbleItemEntities) this).ShowProfileAngleDrawing = false;
    ((MarbleItemEntities) this).RemoveProfileAngle = false;
    ((MarbleItemExtend) this).JobOpenClearAllProfiles = true;
    ((MarbleItemExtend) this).UseAlwaysPocketForCam = false;
    ((MarbleItemExtend) this).UseAlwaysInsideContourForCam = true;
    ((MarbleItemExtend) this).ShowSupportBlockInfoAtGCode = true;
    ((MarbleItemExtend) this).ShowOperationInfoAtGCode = true;
    ((MarbleItemExtend) this).ShowProfileInfoAtGCode = true;
    ((MarbleItemExtend) this).ChangeG2G3DirForRightRefProfile = true;
    ((MarbleItemExtend) this).ChangeG2G3DirForLeftRefProfile = true;
    ((MarbleItemOperations) this).ChangeCwCCWDirForRightRefProfile = true;
    ((MarbleItemOperations) this).RightProfileActive = false;
    ((MarbleItemOperations) this).NotchOperationAlwaysFirst = false;
    ((MarbleItemOperations) this).NotchHorizontalUseMilling = true;
    ((MarbleItemOperations) this).OperationEditChangeWithoutOk = false;
    ((MarbleItemOperations) this).InsertOperationIfSamePositionAndSmallSize = true;
    ((MarbleItemOperations) this).ShowBottomReferanceEntity = false;
    ((MarbleItemOperations) this).ShowBackReferanceEntity = false;
    ((MarbleItemOperations) this).LeftToRightCopyRotateKeyHole = false;
    ((MarbleItemOperations) this).LeftToRightCopyChangeCamDirection = false;
    ((MarbleItemOperations) this).NotchAlwaysSafeZ = true;
    ((MarbleTempVars) this).SortType = ProfileSortMethods.OnlyXDirection;
    ((MarbleTempVars) this).RegenDeviation = 0.01;
    ((MarbleTempVars) this).CollisionControlMinStep = 10;
    ((MarbleTempVars) this).ParabolicMoveBetweenPlanes = false;
    ((MarbleTempVars) this).ParabolicSafeDistance = 50.0;
    ((MarbleTempVars) this).ParabolicMoveFeed = 100.0;
    ((MarbleTempVars) this).ParabolicAllowedAxes = ProfileParaolicAxesType.Axes4;
    ((MarbleTempVars) this).AutoSave = true;
    ((MarbleTempVars) this).AutoSaveWithTimeFileName = false;
    ((MarbleTempVars) this).AutoSaveTimeSec = 60;
    ((MarbleTempVars) this).AutoSaveMaxCount = 15;
    ((MarbleTempVars) this).UseDrillToolForDrill = false;
    ((MarbleTempVars) this).PlaneToPlaneSafeDisance = 30.0;
    ((MarbleTempVars) this).NotchSideSafeAtXAxis = true;
    ((MarbleTempVars) this).NotchVerticalSafeAtXAxis = true;
    ((MarbleTempVars) this).NotchVerticalForbiddenAtSide = false;
    ((MarbleTempVars) this).alarmIfToolDiaDifferentThenHoleDia = false;
    ((MarbleTempVars) this).SimAAxisDirection = 1.0;
    ((MarbleTempVars) this).SimYAxisDirection = -1.0;
    ((MarbleTempVars) this).SimAddZAxisKinematicAndToolLength = true;
    ((MarbleTempVars) this).ProfileStartAllowedNegativeDistance = -30.0;
    ((MarbleTempVars) this).ProfileEndAllowedPositiveDistance = 30.0;
    ((MarbleTempVars) this).ProfilePreviewRefDrawingThickness = 2.0;
    ((MarbleTempVars) this).ProfilePreviewRefDrawingExtraHeight = 10.0;
    ((MarbleTempVars) this).ProfileDrawingRefThickness = 10.0;
    ((MarbleTempVars) this).SimilasyonClamperOpenDistance = 250.0;
    ((MarbleTempVars) this).SaveStlFileWhileCreatingCode = true;
    ((MarbleTempVars) this).SaveImageFileWhileCreatingCode = false;
    ((MarbleTempVars) this).SimulationCanStartFromRightProfile = false;
    ((MarbleTempVars) this).ImageScaleFactor = 1.0;
    ((MarbleTempVars) this).SimulasyonGCodeWindowWidth = 500;
    ((MarbleTempVars) this).SimulasyonGCodeWindowHeight = 650;
    ((MarbleTempVars) this).MinSpindleSpeed = 100.0;
    ((MarbleTempVars) this).ClamperChar = "C";
    ((MarbleTempVars) this).PriorityChar = "P";
    ((MarbleTempVars) this).PlaneThickness = 4.0;
    ((MarbleTempVars) this).LongProfileMCode = "111";
    ((MarbleTempVars) this).BottomProfileMCode = "112";
    ((MarbleTempVars) this).LongBottomProfileMCode = "113";
    ((MarbleTempVars) this).G91Mode = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
