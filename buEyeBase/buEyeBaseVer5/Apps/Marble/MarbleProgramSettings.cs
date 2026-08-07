// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleProgramSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Components;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleProgramSettings : buSerilization5
{
  public static List<List<Pnt3D>> pntTeachGrids;
  public static MarbleSelection SelectedItem;
  public static ToolBase5 activeToolSaw;
  public static ToolBase5 activeToolMilling;
  public static ToolBase5 activeToolMillingHead;
  public static ToolBase5 activeToolWaterjet;
  public static ToolBase5 activeToolAirDry;
  public static ToolBase5 activeToolLaserPointer;
  public static List<ToolBase5> ToolInMagazine;
  public static List<ToolBase5> ToolMillings;
  public static List<ToolBase5> ToolMillingHeads;
  public static List<ToolBase5> ToolSaws;
  public static marbleCounterTopBase activeCountertop;
  public static marbleCounterTopItem activeCountertopItem;
  public static marbleEdgeItem activeCountertopEdge;
  public static marbleCountertopCornerPars activeCountertopCorner;
  public static marbleCounterTopItem newCountertopItem;
  public static buEntitiesGroup CountertopRefEntGroup;
  public static List<MarbleJob> UndoJobList;
  public static List<List<MarbleItem>> UndoList;
  public static List<marbleMaterialType> MaterialList;
  public static buEnableTwoValueList CountertopEdgeControl;
  public static byte f004813;
  public static readonly buMarbleCalc.\u003C\u003Ec \u003C\u003E9;
  public static Func<(double, double), double> \u003C\u003E9__92_1;
  public Vector3D \u0001;
  public List<MarbleItem> Items;
  public List<MarbleVacuumCut> VacuumCuts;
  public List<MaterialBase5> VacuumMaterials;
  public List<List<MaterialBase5>> SimMaterials;
  public buEntitiesGroup SheetGroup;
  public List<MarbleItemOperations> Operations;
  public List<Entity> SheetSolidEntities;
  public List<camTp> Cams;
  public camTp Cam;
  public MaterialBase5 Material;
  public BoxSize5 SizeOfOperations;
  public bool CamCalculated;
  public bool isSimulationDone;
  public bool isGCodeCreated;
  public bool isFileSend;
  public bool isSawAvailable;
  public bool isMillingAvailable;
  public bool isMillingHeadAvailable;
  public bool isCommonPathDone;
  public bool isWaterJetAvailable;
  public int VacuumSelectedIndex;
  public string Name;
  public string GCode;
  public List<InfoType> TotalMessages;
  public static byte f00482F;
  public string ItemName;
  public string FileName;
  public string FileNameFull;
  public bool IsSorted;
  public bool isSimulationDone;
  public bool isError;
  public bool isVerticalItem;
  public bool isTextVertical;
  public bool isVacuumCut;
  public bool MoveAble;
  public bool Enable;
  public new bool Visible;
  public bool Selected;
  public bool MoveAfterDone;
  public bool DontCheckPartLimits;
  public string TextureName;
  public double MaterialThickness;
  public double BaseHeight;
  public double SawExtensionDistance;
  public double OffsetX;
  public double OffsetY;
  public int Transparency;
  public int ID;
  public int MovedID;
  public int indexItem;
  public MarbleItemType ItemType;

  public MarbleProgramSettings(ProfileSettings data)
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

  public abstract void m001E9D();

  public MarbleProgramSettings()
  {
    ((MarbleTempVars) this).TreeItemColor = Color.Black;
    ((MarbleTempVars) this).TreeItemSelectedColor = Color.Green;
    ((MarbleTempVars) this).TreeOPColor = Color.Black;
    ((MarbleTempVars) this).TreeOPSelectedColor = Color.LimeGreen;
    ((MarbleTempVars) this).TreeOPWarningColor = Color.DarkOrange;
    ((MarbleTempVars) this).TreeOPErrorColor = Color.Red;
    ((MarbleTempVars) this).TreeOPInfoColor = Color.Red;
    ((MarbleTempVars) this).FreePlaneColor = Color.Green;
    ((MarbleTempVars) this).ProfileRefeanceColor = Color.Purple;
    ((MarbleTempVars) this).OnlineDrawCamColor = Color.Red;
    ((MarbleTempVars) this).OnlineDrawContourColor = Color.Blue;
    ((MarbleTempVars) this).OperationSelectedColor = Color.Gold;
    ((MarbleTempVars) this).OperationDisableColor = Color.Red;
    ((MarbleTempVars) this).OnlineDrawThickness = 2.0;
    ((MarbleTempVars) this).ProfileRefeanceTranparentLeft = 70;
    ((MarbleTempVars) this).ProfileRefeanceTranparentBottom = 40;
    ((MarbleTempVars) this).ProfileRefeanceTranparentBack = 40;
    ((MarbleTempVars) this).TreeItemFontSize = 11.0;
    ((MarbleTempVars) this).TreeOPFontSize = 9.0;
    ((MarbleTempVars) this).TreeItemFontName = "Arial";
    ((MarbleTempVars) this).TreeOPFontName = "Microsoft Sans Serif";
    ((MarbleTempVars) this).TreeMessageFontName = "Microsoft Sans Serif";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MarbleProgramSettings(ProfileVisualSettings data)
  {
    ((MarbleTempVars) this).TreeItemColor = Color.Black;
    ((MarbleTempVars) this).TreeItemSelectedColor = Color.Green;
    ((MarbleTempVars) this).TreeOPColor = Color.Black;
    ((MarbleTempVars) this).TreeOPSelectedColor = Color.LimeGreen;
    ((MarbleTempVars) this).TreeOPWarningColor = Color.DarkOrange;
    ((MarbleTempVars) this).TreeOPErrorColor = Color.Red;
    ((MarbleTempVars) this).TreeOPInfoColor = Color.Red;
    ((MarbleTempVars) this).FreePlaneColor = Color.Green;
    ((MarbleTempVars) this).ProfileRefeanceColor = Color.Purple;
    ((MarbleTempVars) this).OnlineDrawCamColor = Color.Red;
    ((MarbleTempVars) this).OnlineDrawContourColor = Color.Blue;
    ((MarbleTempVars) this).OperationSelectedColor = Color.Gold;
    ((MarbleTempVars) this).OperationDisableColor = Color.Red;
    ((MarbleTempVars) this).OnlineDrawThickness = 2.0;
    ((MarbleTempVars) this).ProfileRefeanceTranparentLeft = 70;
    ((MarbleTempVars) this).ProfileRefeanceTranparentBottom = 40;
    ((MarbleTempVars) this).ProfileRefeanceTranparentBack = 40;
    ((MarbleTempVars) this).TreeItemFontSize = 11.0;
    ((MarbleTempVars) this).TreeOPFontSize = 9.0;
    ((MarbleTempVars) this).TreeItemFontName = "Arial";
    ((MarbleTempVars) this).TreeOPFontName = "Microsoft Sans Serif";
    ((MarbleTempVars) this).TreeMessageFontName = "Microsoft Sans Serif";
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

  public abstract void m001EA0();
}
