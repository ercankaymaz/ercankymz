namespace buEyeBaseVer5.Apps.Marble;

public class MarbleMachineSimultionSettings : buSerilization5
{
	public bool DrawHead = true;

	public bool DrawMachine = false;

	public bool DrawLathe = false;

	public bool DrawSawTool = true;

	public bool DrawMillingTool = true;

	public bool DrawMilling5AxisTool = true;

	public bool DrawMillingHeadTool = true;

	public bool DrawAirDry = false;

	public bool DrawLaserPointer = false;

	public bool DrawWaterjet = false;

	public bool DrawAllTool = true;

	public bool DrawSawToolForMillingHeadOperation = false;

	public bool MovePartFromKinematicDistances = true;

	public double SimACAxesZDistance = 0.0;

	public double SimDrawCommonOffsetX = 0.0;

	public double SimDrawCommonOffsetY = 0.0;

	public double SimDrawCommonOffsetZ = 0.0;

	public double SimDrawMillingToolOffsetX = 0.0;

	public double SimDrawMillingToolOffsetY = 0.0;

	public double SimDrawMillingToolOffsetZ = 0.0;

	public double SimDrawSpindleOffsetX = 0.0;

	public double SimDrawSpindleOffsetY = 0.0;

	public double SimDrawSpindleOffsetZ = 0.0;

	public double SimSpindleG54OffsetZ = 0.0;

	public double SimDrawAirDryOffsetX = 0.0;

	public double SimDrawAirDryOffsetY = 0.0;

	public double SimDrawAirDryOffsetZ = 0.0;

	public double SimDrawLaserPointerOffsetX = 0.0;

	public double SimDrawLaserPointerOffsetY = 0.0;

	public double SimDrawLaserPointerOffsetZ = 0.0;

	public double SimDrawWaterjetOffsetX = 0.0;

	public double SimDrawWaterjetOffsetY = 0.0;

	public double SimDrawWaterjetOffsetZ = 0.0;

	public double ExternalMillingSpindleStroke = 0.0;

	public double SimDrawMillingHeadToolXOffset = 0.0;

	public double SimDrawMillingHeadToolYOffset = 0.0;

	public double SimDrawMillingHeadToolZOffset = 0.0;

	public double SimCalcMillingToolXOffset = 0.0;

	public double SimCalcMillingToolYOffset = 0.0;

	public double SimCalcMillingToolZOffset = 0.0;

	public double SimCalcMillingHeadToolXOffset = 0.0;

	public double SimCalcMillingHeadToolYOffset = 0.0;

	public double SimCalcMillingHeadToolZOffset = 0.0;

	public double SimCalcLaserPointerToolXOffset = 0.0;

	public double SimCalcLaserPointerToolYOffset = 0.0;

	public double SimCalcLaserPointerToolZOffset = 0.0;

	public double SimCalcAirDryToolXOffset = 0.0;

	public double SimCalcAirDryToolYOffset = 0.0;

	public double SimCalcAirDryToolZOffset = 0.0;

	public double SimCalcWaterjetToolXOffset = 0.0;

	public double SimCalcWaterjetToolYOffset = 0.0;

	public double SimCalcWaterjetToolZOffset = 0.0;

	public double SimulatioOnlineMoveXOffset = 0.0;

	public double SimulatioOnlineMoveYOffset = 0.0;

	public double SimulatioOnlineMoveZOffset = 0.0;

	public double SimulatioOfflineMoveXOffset = 0.0;

	public double SimulatioOfflineMoveYOffset = 0.0;

	public double SimulatioOfflineMoveZOffset = 0.0;

	public bool OnlineSimulation = true;

	public int SimInterval = 20;

	public double SimulationG0DevideLength = 50.0;

	public double SimulationG1DevideLength = 20.0;
}
