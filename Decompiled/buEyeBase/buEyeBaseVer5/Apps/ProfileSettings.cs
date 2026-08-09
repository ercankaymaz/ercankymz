using System;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileSettings : buSerilization5
{
	public int MaterialTranspancy = 250;

	public double EachLayerSafeDistance = 1.0;

	public double EachLayerMinThickness = 0.2;

	public double EachLayerMaxThickness = 1200.0;

	public bool EachLayerFromArea = true;

	public int EachLayerAreaDevideCount = 10;

	public double EachLayerConnectGap = 0.5;

	public int ProfileMaxClamper = 4;

	public Color SupportBlockZColor = Color.Yellow;

	public Color ProfileColor = Color.DarkGray;

	public bool FindToolAuto = true;

	public bool FindToolAutoFromDepth = true;

	public double MinXMove = 100.0;

	public double MinYMove = -2000.0;

	public double MinZMove = -1000.0;

	public double MinAMove = -90.0;

	public double MaxXMove = 10000.0;

	public double MaxYMove = 2000.0;

	public double MaxZMove = 1000.0;

	public double MaxAMove = 90.0;

	public bool ShowToolChangeInSimulation = true;

	public double ToolChangeX = 0.0;

	public double ToolChangeY = 0.0;

	public double ToolChangeZ = 200.0;

	public double ToolChangeA = 0.0;

	public double MachineLength = 3200.0;

	public double CutQuality = 0.05;

	public bool ConnectSmallGap = true;

	public double GapConnectionForProfile = 0.02;

	public double ProfileSortResolution = 0.05;

	public double MinProfileFilterLength = 0.0;

	public SortingIntersectionRulesType IntersectionRules = SortingIntersectionRulesType.LowerIndex;

	public double ProfileSizeExceedDepthLimit = 5.0;

	public bool CalculateClamperEveryTime = false;

	public bool ManuelClamperSet = false;

	public bool NoClampedOutput = false;

	public double ParkPositionX = 100.0;

	public double ParkPositionY = 0.0;

	public double ParkPositionZ = 250.0;

	public double ToolHolderLength = 73.0;

	public double ToolPensDiameter = 63.0;

	public double FirstPositionOffset = 100.0;

	public bool GoFirstPosition = true;

	public bool AutoOpenLastLoadedProfile = true;

	public bool AutoOpenLastLoadedProfileAndOperations = true;

	public bool SaveCurrentProfilesWhileProgramClosing = false;

	public bool ToolSpeedDataToOperationSpeedData = true;

	public bool ToolDistanceDataToOperationDistanceData = true;

	public bool AutoCloseWater = false;

	public bool DontAddLineFromExternalFile = true;

	public bool ClamperCanMoveInsideProfileLength = true;

	public bool MultipleEdit = false;

	public ProfilePositionCalculationMode ProfilePositionCalculation = ProfilePositionCalculationMode.ToolTipPoint;

	public ProfileSafeDistanceMode ProfileSafeDistanceForPlanes = ProfileSafeDistanceMode.G53Mode;

	public ProfileOutSizeClamperMode ProfileOutsizeClamperMode = ProfileOutSizeClamperMode.Offset;

	public ProfileOperationWindowType OperationWindow = ProfileOperationWindowType.AutoHideDock;

	public ProfileOperationWindowCloseType OperationWindowClose = ProfileOperationWindowCloseType.Hide;

	public GoFirstPositionType GoFirstPositionMode = GoFirstPositionType.ParkPosition;

	public ToolFindType FindToolType = ToolFindType.MostSmall;

	public ProfileYAxisDirection YDirection = ProfileYAxisDirection.NegativeDirection;

	public ProfileXAxisDirection XDirection = ProfileXAxisDirection.Left;

	public LeftRightType XDirRefType = LeftRightType.Left;

	public bool ShowCabinet = false;

	public buViewTypeBasic PreviewViewType = buViewTypeBasic.Right;

	public bool ShowPreviewSides = true;

	public bool ShowOperationButton = true;

	public Color PreviewSideColor = Color.Green;

	public Color PreviewDoneOperationColor = Color.Orange;

	public Color PreviewActiveOperationColor = Color.Cyan;

	public Color GhostClamperColor = Color.LightPink;

	public int GhostClamperTransparency = 100;

	public int NotchToolNo = 4;

	public double NotchMinSpeed = 100.0;

	public double NotchMaxSpeed = 5000.0;

	public double MillingToolMaxSpeed = 30000.0;

	public double ProfileMaxLength = 10000.0;

	public double ProfileMaxWidth = 1000.0;

	public double ProfileMaxHeight = 1000.0;

	public double PlaneMoveSafeDistance = 20.0;

	public bool ProfileAddWidthHeightReadOnly = false;

	public bool ChangeAAxisWhileMoveBetweenPlanes = false;

	public double TopOperationClamperMoveZValue = 130.0;

	public bool AutoPeckingAddDefault = false;

	public double AutoPeckingUpDefaultDistance = 0.0;

	public bool RightProfileMakeAsMirror = true;

	public bool AllGCodeAsG1 = false;

	public bool UseUndoBuffer = false;

	public bool OperationFrontBackMirrorYDirToAnotherPlane = false;

	public bool ShowProfileAngleDrawing = false;

	public bool RemoveProfileAngle = false;

	public bool JobOpenClearAllProfiles = true;

	public bool UseAlwaysPocketForCam = false;

	public bool UseAlwaysInsideContourForCam = true;

	public bool ShowSupportBlockInfoAtGCode = true;

	public bool ShowOperationInfoAtGCode = true;

	public bool ShowProfileInfoAtGCode = true;

	public bool ChangeG2G3DirForRightRefProfile = true;

	public bool ChangeG2G3DirForLeftRefProfile = true;

	public bool ChangeCwCCWDirForRightRefProfile = true;

	public bool RightProfileActive = false;

	public bool NotchOperationAlwaysFirst = false;

	public bool NotchHorizontalUseMilling = true;

	public bool OperationEditChangeWithoutOk = false;

	public bool InsertOperationIfSamePositionAndSmallSize = true;

	public bool ShowBottomReferanceEntity = false;

	public bool ShowBackReferanceEntity = false;

	public bool LeftToRightCopyRotateKeyHole = false;

	public bool LeftToRightCopyChangeCamDirection = false;

	public bool NotchAlwaysSafeZ = true;

	public ProfileSortMethods SortType = ProfileSortMethods.OnlyXDirection;

	public double RegenDeviation = 0.01;

	public int CollisionControlMinStep = 10;

	public bool ParabolicMoveBetweenPlanes = false;

	public double ParabolicSafeDistance = 50.0;

	public double ParabolicMoveFeed = 100.0;

	public ProfileParaolicAxesType ParabolicAllowedAxes = ProfileParaolicAxesType.Axes4;

	public bool AutoSave = true;

	public bool AutoSaveWithTimeFileName = false;

	public int AutoSaveTimeSec = 60;

	public int AutoSaveMaxCount = 15;

	public bool UseDrillToolForDrill = false;

	public double PlaneToPlaneSafeDisance = 30.0;

	public bool NotchSideSafeAtXAxis = true;

	public bool NotchVerticalSafeAtXAxis = true;

	public bool NotchVerticalForbiddenAtSide = false;

	public bool alarmIfToolDiaDifferentThenHoleDia = false;

	public double SimAAxisDirection = 1.0;

	public double SimYAxisDirection = -1.0;

	public bool SimAddZAxisKinematicAndToolLength = true;

	public double ProfileStartAllowedNegativeDistance = -30.0;

	public double ProfileEndAllowedPositiveDistance = 30.0;

	public double ProfilePreviewRefDrawingThickness = 2.0;

	public double ProfilePreviewRefDrawingExtraHeight = 10.0;

	public double ProfileDrawingRefThickness = 10.0;

	public double SimilasyonClamperOpenDistance = 250.0;

	public bool SaveStlFileWhileCreatingCode = true;

	public bool SaveImageFileWhileCreatingCode = false;

	public bool SimulationCanStartFromRightProfile = false;

	public double ImageScaleFactor = 1.0;

	public int SimulasyonGCodeWindowWidth = 500;

	public int SimulasyonGCodeWindowHeight = 650;

	public double MinSpindleSpeed = 100.0;

	public string ClamperChar = "C";

	public string PriorityChar = "P";

	public double PlaneThickness = 4.0;

	public string LongProfileMCode = "111";

	public string BottomProfileMCode = "112";

	public string LongBottomProfileMCode = "113";

	public bool G91Mode = false;

	public ProfileSettings()
	{
	}

	public ProfileSettings(ProfileSettings data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
