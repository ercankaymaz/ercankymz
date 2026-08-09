using System;

namespace buClass;

[Serializable]
public class SystemRuntime : buSerilization
{
	public bool Alarm = false;

	public bool Run = false;

	public bool Move = false;

	public bool Pause = false;

	public bool HomingDone = false;

	public bool FileLoaded = false;

	public bool Enabled = false;

	public bool Water = false;

	public bool Laser = false;

	public bool Spindle = false;

	public bool Saw = false;

	public bool Waterjet = false;

	public bool FirstPLCRead = false;

	public bool FeedIsZero = false;

	public bool RtcpActivated = false;

	public bool InitDone = false;

	public bool MAcOk = false;

	public bool Auto = false;

	public bool Manuel = false;

	public bool SimulatedAxes = false;

	public bool SimulatedIO = false;

	public bool WarningOccured = false;

	public bool WagonUp = false;

	public bool SemiAuto = false;

	public bool Finished = false;

	public bool PartZero = false;

	public bool HandWheelActivated = false;

	public bool ParameterUpdated = false;

	public bool Calculated = false;

	public bool Pens = false;

	public bool CameraReady = false;

	public bool CruiseControl = false;

	public bool EthercatResetExecuting = false;

	public bool MaintananceAir = false;

	public bool MaintananceHidroMotor = false;

	public bool MaintananceCabinet = false;

	public bool MaintananceLubricate = false;

	public bool MaintananceMachineClear = false;

	public bool AxesMessageAvailable = false;

	public bool InstantMessageAvailable = false;

	public bool GantryOk = false;

	public bool ToolUpdate = false;

	public bool ToolChanged = false;

	public bool SawUpdate = false;

	public bool MillingUpdate = false;

	public bool MillingHeadUpdate = false;

	public bool MaterialUpdate = false;

	public bool isSawActivated = false;

	public bool isMillingActivated = false;

	public bool isMillingHeadActivated = false;

	public bool isWaterJetActivated = false;

	public bool isZLowerThenMaterialSafeDis = false;

	public bool MachineLight = false;

	public int AxesEnabledBitValue = 0;

	public int AxesHomeDoneBitValue = 0;

	public int AxesStandstillBitValue = 0;

	public int AxesErrorBitValue = 0;

	public int AlarmCount = 0;

	public int WarningCount = 0;

	public int InfoCount = 0;

	public int MessageCount = 0;

	public int WarningLocalCount = 0;

	public int Status = 0;

	public int ActiveSpindleNo = 0;

	public int InitStep = 0;

	public int AutoStep = 0;

	public int StartStep = 0;

	public int ActiveToolType = -1;

	public int ActiveHead = 1;

	public double FeedOverride = 0.0;

	public double FeedOverrideG0 = 0.0;

	public double FeedOverrideG1 = 0.0;

	public double SpindleOverride = 0.0;

	public double SawOverride = 0.0;

	public double SpindleActualCurrent = 0.0;

	public double SawActualCurrent = 0.0;

	public double SpindleSpeed = 0.0;

	public double SawSpeed = 0.0;

	public TimeSpan OperationTime = default(TimeSpan);

	public string OperationTimeAsString = "";

	public AppWarning WarningLast = new AppWarning();

	public Pnt9D actualPositions = new Pnt9D();

	public Pnt9D offsetedPositions = new Pnt9D();

	public override string ToString()
	{
		return "Status: " + Status + " ; Run: " + Run + " ; HomingDone: " + HomingDone + " ; Enabled: " + Enabled + " ; Alarm Count: " + AlarmCount;
	}
}
