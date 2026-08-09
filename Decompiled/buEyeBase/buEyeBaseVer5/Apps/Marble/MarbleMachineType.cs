using System;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public enum MarbleMachineType
{
	BridgeCut5Axis,
	BridgeCut4Axis,
	BridgeCut3Axis,
	SideCut5Axis,
	SideCut4Axis,
	SideCut3Axis,
	Milling3Axis,
	Milling5Axis,
	DualHeadMilling5AxisSaw5Axis
}
