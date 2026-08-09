using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningAreaHeightsParamsAutomaticHeightsType
{
	ShpAhtMinMaxFromMachSurf,
	ShpAhtMinMaxFromStock,
	ShpAhtMinMaxFromBoth,
	ShpAhtMaxFromMachCurve,
	ShpAhtMinFromMachCurve
}
