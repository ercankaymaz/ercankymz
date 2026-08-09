using System.Reflection;
using buClass;
using buEyeBaseVer5;

namespace buMarble;

public class clsAppMarbleOPVar : buSerilization5
{
	public double LaserOnOffTimerSec = 0.1;

	public double WaterOnOffTimerSec = 0.1;

	public double WaterOffDelayTimerSec = 3.0;

	public double WagonHidroStopSec = 10.0;

	public double ToolChangePositionA = 0.0;

	public double ToolChangePositionC = 0.0;

	public double ToolChangeXSafeDistance = 0.0;

	public double ToolChangeYSafeDistance = 0.0;

	public double ToolChangeSafePositionZ = 0.0;

	public double ToolChangeUpPositionZ = 0.0;

	public double ToolChangeBeforePositionX = 0.0;

	public double ToolChangeSlowVelocity = 10.0;

	public double ToolChangeFastVelocity = 50.0;

	public double ToolChangeLeaveVelocity = 10.0;

	public double ToolChangeTakeVelocity = 10.0;

	public double ToolMillingClampOpenTimeSec = 5.0;

	public double ToolMillingClampCloseTimeSec = 5.0;

	public MarbleToolChangeType ToolChangeDirection = MarbleToolChangeType.XDirection;

	public int ToolMillingCount = 10;

	public int ToolMillingHeadCount = 10;

	public int ToolSawCount = 10;

	public int ToolChangeCount = 9;

	public double ToolChangeMaxSawDiameter = 500.0;

	public int toolActiveNo = -1;

	public double MaxSpindleToolLengthForA45 = 300.0;

	public bool LimitToolSawZMovement = false;

	public bool LimitToolMillingZMovement = false;

	public bool LimitToolMillingHeadZMovement = false;

	public double AtcOpenTimeSec = 5.0;

	public double AtcCloseTimeSec = 5.0;

	public double AtcForwardTimeSec = 5.0;

	public double AtcBackwardTimeSec = 5.0;

	public double AtcUpTimeSec = 5.0;

	public double AtcDownTimeSec = 5.0;

	public double AtcOpenTimeoutSec = 10.0;

	public double AtcCloseTimeoutSec = 10.0;

	public double AtcForwardTimeoutSec = 10.0;

	public double AtcBackwardTimeoutSec = 10.0;

	public double AtcUpTimeoutSec = 10.0;

	public double AtcDownTimeoutSec = 10.0;

	public MarbleATCType AtcType = MarbleATCType.UpDown;

	public double SawModePositionX = 90.0;

	public double SawModePositionY = 90.0;

	public double SawModePositionZ = 90.0;

	public double SawModePositionA = 90.0;

	public double SawModePositionC = 0.0;

	public double MillingModePositionX = 0.0;

	public double MillingModePositionY = 0.0;

	public double MillingModePositionZ = 0.0;

	public double MillingModePositionA = 0.0;

	public double MillingModePositionC = 0.0;

	public double MillingHeadModePositionX = 0.0;

	public double MillingHeadModePositionY = 0.0;

	public double MillingHeadModePositionZ = 0.0;

	public double MillingHeadModePositionA = 0.0;

	public double MillingHeadModePositionC = 0.0;

	public double WaterJetModePositionX = 0.0;

	public double WaterJetModePositionY = 0.0;

	public double WaterJetModePositionZ = 0.0;

	public double WaterJetModePositionA = 0.0;

	public double WaterJetModePositionC = 0.0;

	public double CameraPositionX = 0.0;

	public double CameraPositionY = 0.0;

	public double CameraPositionZ = 0.0;

	public double CameraPositionA = 0.0;

	public double CameraPositionC = 0.0;

	public double WagonUpPositionX = 0.0;

	public double WagonUpPositionY = 0.0;

	public double WagonUpPositionZ = 0.0;

	public double WagonUpPositionA = -45.0;

	public double WagonUpPositionC = 0.0;

	public double SawExtraG54OffsetX = 0.0;

	public double SawExtraG54OffsetY = 0.0;

	public double SawExtraG54OffsetZ = 0.0;

	public double MillingExtraG54OffsetX = 0.0;

	public double MillingExtraG54OffsetY = 0.0;

	public double MillingExtraG54OffsetZ = 0.0;

	public double MillingHeadExtraG54OffsetX = 0.0;

	public double MillingHeadExtraG54OffsetY = 0.0;

	public double MillingHeadExtraG54OffsetZ = 0.0;

	public double AirDryExtraG54OffsetX = 0.0;

	public double AirDryExtraG54OffsetY = 0.0;

	public double AirDryExtraG54OffsetZ = 0.0;

	public double LaserPointerExtraG54OffsetX = 0.0;

	public double LaserPointerExtraG54OffsetY = 0.0;

	public double LaserPointerExtraG54OffsetZ = 0.0;

	public double SawDiaMeasurePositionX = 90.0;

	public double SawDiaMeasurePositionY = 90.0;

	public double SawDiaMeasurePositionFastZ = 90.0;

	public double SawDiaMeasurePositionLimitZ = 90.0;

	public double SawDiaMeasurePositionA = 90.0;

	public double SawDiaMeasurePositionC = 0.0;

	public double SawDiaMeasureConstant = 0.0;

	public double SawDiaMeasureMinDaimeter = 50.0;

	public double SawDiaMeasureMaxDaimeter = 1000.0;

	public double MillingLenMeasurePositionX = 90.0;

	public double MillingLenMeasurePositionY = 90.0;

	public double MillingLenMeasurePositionFastZ = 90.0;

	public double MillingLenMeasurePositionLimitZ = 90.0;

	public double MillingLenMeasurePositionA = 90.0;

	public double MillingLenMeasurePositionC = 0.0;

	public double MillingLenMeasureConstant = 0.0;

	public double MillingLenMeasureMinLength = 10.0;

	public double MillingLenMeasureMaxLength = 1000.0;

	public double MillingHeadLenMeasurePositionX = 90.0;

	public double MillingHeadLenMeasurePositionY = 90.0;

	public double MillingHeadLenMeasurePositionFastZ = 90.0;

	public double MillingHeadLenMeasurePositionLimitZ = 90.0;

	public double MillingHeadLenMeasurePositionA = 90.0;

	public double MillingHeadLenMeasurePositionC = 0.0;

	public double MillingHeadLenMeasureConstant = 0.0;

	public double MillingHeadLenMeasureMinLength = 10.0;

	public double MillingHeadLenMeasureMaxLength = 1000.0;

	public double MaterialMeasurePositionFastZ = 90.0;

	public double MaterialMeasurePositionLimitZ = 90.0;

	public double MaterialMeasurePositionA = 90.0;

	public double MaterialMeasurePositionC = 0.0;

	public double MaterialMeasureConstant = 0.0;

	public double MaterialMeasureUpTimeOutSec = 5.0;

	public double MaterialMeasureDownTimeOutSec = 5.0;

	public double MaterialMeasureMinThickness = 5.0;

	public double MaterialMeasureMaxThickness = 50.0;

	public double MaterialMeasureFastVelocity = 20.0;

	public double MaterialMeasureSlowVelocity = 20.0;

	public double MaterialMeasureAccDec = 2000.0;

	public double MaterialMeasureJerk = 5000.0;

	public double MaterialMeasureTimeOutSec = 30.0;

	public double MaterialMeasureMaxSawDiameter = 500.0;

	public double MaterialMeasureXBorderOffset = 20.0;

	public double MaterialMeasureYBorderOffset = 20.0;

	public MarbleMaterialMeasureType MaterialMeasureType = MarbleMaterialMeasureType.Point1;

	public AutoManuel MaterialMeasureMode = AutoManuel.Auto;

	public bool MaterialMeasureUseG54OffsetForXY = true;

	public double MaterialMeasureG54OffsetX = 0.0;

	public double MaterialMeasureG54OffsetY = 0.0;

	public double MaterialMeasureMaxDifference = 2.0;

	public double MaterialMeasurePistonDownTimeSec = 5.0;

	public bool WarmUpSawNeccesary = false;

	public bool WarmUpMillingNeccesary = false;

	public double WarmUpMillingSpeed1 = 3000.0;

	public double WarmUpMillingSpeed2 = 5000.0;

	public double WarmUpMillingSpeed3 = 8000.0;

	public double WarmUpMillingTimeSec1 = 10.0;

	public double WarmUpMillingTimeSec2 = 10.0;

	public double WarmUpMillingTimeSec3 = 10.0;

	public double WarmUpSawSpeed1 = 1000.0;

	public double WarmUpSawSpeed2 = 2000.0;

	public double WarmUpSawSpeed3 = 2500.0;

	public double WarmUpSawTimeSec1 = 10.0;

	public double WarmUpSawTimeSec2 = 10.0;

	public double WarmUpSawTimeSec3 = 10.0;

	public double ToolMeasureCoverOnTimeSec = 1.0;

	public double ToolMeasureCoverOffTimeSec = 1.0;

	public double ToolMeasureFastVelocity = 20.0;

	public double ToolMeasureApproachSlowVelocity = 20.0;

	public double ToolMeasureLeaveSlowVelocity = 20.0;

	public double ToolMeasureAccDec = 2000.0;

	public double ToolMeasureJerk = 5000.0;

	public double ToolMeasurePistonUpTimeSec = 5.0;

	public double AAxisAllowedZSafePosition = 0.0;

	public double SawMaxSpeed = 3000.0;

	public double SawMaxSpeedAtA90 = 3000.0;

	public double SawStartTimerSec = 3.0;

	public double SawStartTimeoutSec = 10.0;

	public double SawStopTimerSec = 3.0;

	public double SawStopTimeoutSec = 10.0;

	public bool SawSpeedAtCheck = false;

	public bool SawStopdAtCheck = false;

	public double SpindleMaxSpeed = 10000.0;

	public double SpindleStartTimerSec = 3.0;

	public double SpindleStartTimeoutSec = 10.0;

	public double SpindleStopTimerSec = 3.0;

	public double SpindleStopTimeoutSec = 10.0;

	public double SpindleUpTimeSec = 0.0;

	public double SpindleDownTimeSec = 0.0;

	public bool SpindleSpeedAtCheck = false;

	public bool SpindleStopdAtCheck = false;

	public bool SpindleCoolAfterStop = false;

	public double SpindleCoolAfterStopTimeSec = 300.0;

	public bool LubricationEnable = false;

	public double LubricationTimeSec = 5.0;

	public double LubricationPeriodWaitMin = 300.0;

	public double LubricationLevelOnOffTimeSec = 10.0;

	public double LubricationBlockOnOffTimeSec = 10.0;

	public bool SpindlePersentageFromPLC = false;

	public bool SpindlePersentageSinglePot = true;

	public bool UseDistanceToGo = false;

	public double BuzzerTimeSec = 2.0;

	public bool BuzzerEnable = false;

	public double VacuumUpTimeSec = 5.0;

	public double VacuumDownTimeSec = 5.0;

	public double VacuumUpTimeOutSec = 5.0;

	public double VacuumDownTimeOutSec = 5.0;

	public double VacuumOnTimeOutSec = 5.0;

	public double VacuumOffTimeOutSec = 5.0;

	public double VacuumFastZPosition = -10.0;

	public double VacuumInTimeoutSec = 5.0;

	public double VacuumOutTimeoutSec = 0.0;

	public double VacuumBlowerTimeSec = 5.0;

	public double VacuumMaxSawDiameter = 500.0;

	public bool VacuumWashBeforeMaterialTake = false;

	public double QuickSpeedMinSpeedLevel = 0.5;

	public double OperationSpeedMinSpeedLevel = 0.5;

	public double CameraPosTimeOutSec = 60.0;

	public double WagonPosTimeOutSec = 60.0;

	public double SawModePosTimeOutSec = 60.0;

	public double MillingModePosTimeOutSec = 60.0;

	public double MillingHeadModePosTimeOutSec = 60.0;

	public double WaterjetModePosTimeOutSec = 60.0;

	public double StartPointPosTimeOutSec = 60.0;

	public double ParkPosTimeOutSec = 60.0;

	public double SawMeasureTimeOutSec = 120.0;

	public double MillingMeasureTimeOutSec = 120.0;

	public double MillingHeadMeasureTimeOutSec = 120.0;

	public double SpindleUpTimeOutSec = 5.0;

	public double SpindleDownTimeOutSec = 5.0;

	public double CoordinateMoveAccDec = 100.0;

	public double CoordinateMoveJerk = 400.0;

	public double CoordinateZMoveAccDec = 100.0;

	public double CoordinateZMoveJerk = 400.0;

	public double AAxisTimeOutSec = 10.0;

	public double AAxisExtraTimeSec = 1.0;

	public bool GoZUpPositionWhenStart = false;

	public MarbleParkModeAfterJob ParkPositionAfterFinishType = MarbleParkModeAfterJob.SafeDistance;

	public bool GoG54XYPosition = false;

	public int SelectedParkPosition = -1;

	public int ParkCount = 10;

	public int G54Count = 10;

	public bool PointAngleCorrection = false;

	public double MachineActiveTotalTime = 0.0;

	public double MachineRunTotalTime = 0.0;

	public double MachinePauseTotalTime = 0.0;

	public bool CNCUnFinished = false;

	public int LastActiveLine = 0;

	public int OverSpeedCounterLimit = 5;

	public double DryRunZOffset = 50.0;

	public double CameraTableXOffsetPos = 0.0;

	public double CameraTableYOffsetPos = 0.0;

	public double CameraCoverOpenTimeSec = 2.0;

	public double CameraEnableTimeSec = 4.0;

	public double CameraAutoCloseTimeSec = 120.0;

	public bool CameraAutoCloseEnable = true;

	public bool CameraCoverAutoCloseEnable = true;

	public bool CameraCoverAvailable = true;

	public bool CameraPowerAvailable = true;

	public bool DontMoveInsideMaterial = false;

	public double SemiAutoWidth = 200.0;

	public double SemiAutoHeight = 200.0;

	public double SemiAutoTargetZ = 0.0;

	public double SemiAutoSafeZ = 50.0;

	public double SemiAutoCutFeed = 40.0;

	public double SemiAutoPlungeFeed = 10.0;

	public bool SemiAutoZAutoUpAfterFinished = false;

	public bool PauseModeWaterDisable = false;

	public bool PauseModeSpindleDisable = false;

	public double PauseTimeSec = 3.0;

	public double MaterialThickness = 20.0;

	public double MaterialWidth = 2000.0;

	public double MaterialHeight = 1000.0;

	public double MaterialMaxThickness = 100.0;

	public double MaterialMinThickness = 0.1;

	public double MaintenanceXAxisLimitMeter = 0.0;

	public double MaintenanceYAxisLimitMeter = 0.0;

	public double MaintenanceZAxisLimitMeter = 0.0;

	public double MaintenanceAAxisLimitMeter = 0.0;

	public double MaintenanceCAxisLimitMeter = 0.0;

	public double MaintenanceHidroMotorHour = 0.0;

	public double MaintenanceLubricateHour = 0.0;

	public double MaintenanceCabinetHour = 0.0;

	public double MaintenanceAirHour = 0.0;

	public double MaintenanceMachineCleaningHour = 0.0;

	public bool AllowXYJogWhileZDownFromMatThick = true;

	public bool AllowAJogWhileZDownFromMatThick = true;

	public bool AllowCJogWhileZDownFromMatThick = true;

	public bool AllowZJogDownWithoutMotorRunning = true;

	public bool ExhibitionMode = false;

	public bool InhibitWaterCheckAlarm = false;

	public bool InhibitWaterLeakCheckAlarm = false;

	public bool InhibitDoorCheckAlarm = false;

	public bool InhibitSawDriveCheckAlarm = false;

	public bool InhibitSpindleDriveCheckAlarm = false;

	public bool InhibitXLimitCheckAlarm = false;

	public bool InhibitYLimitCheckAlarm = false;

	public bool InhibitZLimitCheckAlarm = false;

	public bool InhibitHidroTermicCheckAlarm = false;

	public bool InhibitAirPreasureCheckAlarm = false;

	public bool InhibitPhaseAlarm = false;

	public bool OptionServoAxisA = false;

	public bool OptionServoAxisY2 = false;

	public bool OptionGantryY2Parallel = false;

	public bool OptionAllAbsoluteEncoder = false;

	public int OptionDigitalInputCount = 32;

	public int OptionDigitalOutputCount = 32;

	public bool OptionCameraEnable = false;

	public bool OptionSlabThicknessEnable = false;

	public bool OptionToolMeasureEnable = false;

	public bool OptionSpindleEnable = false;

	public bool OptionAutoToolChanger = false;

	public bool OptionVacuumEnable = false;

	public bool OptionTableEnable = true;

	public bool OptionLubricationEnable = false;

	public bool OptionRTCPEnable = true;

	public bool OptionCrouseControlEnable = true;

	public bool OptionPensEnable = true;

	public bool OptionWarmMotors = false;

	public clsAppMarbleOPVar()
	{
	}

	public clsAppMarbleOPVar(clsAppMarbleOPVar data)
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
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
