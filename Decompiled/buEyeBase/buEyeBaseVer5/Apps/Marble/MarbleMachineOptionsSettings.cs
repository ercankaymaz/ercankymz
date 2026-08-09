namespace buEyeBaseVer5.Apps.Marble;

public class MarbleMachineOptionsSettings : buSerilization5
{
	public MarbleMachineType MachineType = MarbleMachineType.BridgeCut5Axis;

	public bool AAxisEnable = true;

	public bool ServoAxisA = false;

	public bool ServoAxisY2 = false;

	public bool GantryY2Parallel = false;

	public bool AllAbsoluteEncoder = false;

	public int DigitalInputCount = 32;

	public int DigitalOutputCount = 32;

	public bool CameraEnable = false;

	public bool CameraCover = false;

	public bool SlabThicknessEnable = false;

	public bool ToolMeasureEnable = false;

	public bool MillingEnable = false;

	public bool MillingHeadEnable = false;

	public bool AutoToolChanger = false;

	public bool VacuumEnable = false;

	public bool TableEnable = true;

	public bool LubricationEnable = false;

	public bool RTCPEnable = true;

	public bool CrouseControlEnable = true;

	public bool PensEnable = true;

	public bool WarmMotors = false;

	public bool WagonEnable = true;

	public bool AirDryEnable = false;

	public bool LaserPointerEnable = false;

	public bool AbsoluteXAxis = false;

	public bool AbsoluteYAxis = false;

	public bool AbsoluteZAxis = false;

	public bool AbsoluteAAxis = false;

	public bool AbsoluteCAxis = false;

	public bool WaterJet = false;

	public string AxisXChar = "X";

	public string AxisYChar = "Y";

	public string AxisZChar = "Z";

	public string AxisAChar = "A";

	public string AxisCChar = "C";

	public string AxisY2Char = "Y2";

	public bool TechnicianReportEnable = false;

	public bool OperationReportEnable = false;
}
