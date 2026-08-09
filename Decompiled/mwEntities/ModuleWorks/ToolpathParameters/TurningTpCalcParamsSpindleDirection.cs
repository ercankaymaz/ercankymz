using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TurningTpCalcParamsSpindleDirection
{
	[Obsolete("Deprecated since 2024.12 and will be removed in 2025.04. Please use SpindleDirection::SdClockwise!")]
	SdClockwise,
	[Obsolete("Deprecated since 2024.12 and will be removed in 2025.04. Please use SpindleDirection::SdCounterclockwise!")]
	SdCounterclockwise
}
