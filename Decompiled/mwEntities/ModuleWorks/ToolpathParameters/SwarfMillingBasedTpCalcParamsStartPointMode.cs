using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum SwarfMillingBasedTpCalcParamsStartPointMode
{
	SptExact,
	SptAutomatic,
	SptUse2Points,
	SptTiltLine,
	SptOnePoint
}
