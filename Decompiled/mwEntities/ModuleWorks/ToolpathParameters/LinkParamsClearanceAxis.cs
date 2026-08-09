using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum LinkParamsClearanceAxis
{
	AxisX,
	AxisY,
	AxisZ,
	AxisCustom,
	MachiningDirection,
	RotaryAxis,
	Auto,
	LastAxis
}
