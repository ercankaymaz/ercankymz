using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum SwarfMillingBasedTpCalcParamsOutsideCornersHandling
{
	OchRollAround,
	OchSharpCorner,
	OchLoop
}
