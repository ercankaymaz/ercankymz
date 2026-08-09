using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum SwarfMillingBasedTpCalcParamsSwarfingMode
{
	SmUseSyncLines,
	SmSyncCurves,
	SmFixedAngleFromZ,
	SmUseMainDir,
	[Obsolete("Deprecated since 2023.08. Please use SmAutomatic2 instead!")]
	SmAutomatic,
	SmShortestDistance,
	SmNormalToLowerCurve,
	SmHugeToolOptimized,
	Sm3Axis,
	Sm4Axis,
	SmIso,
	SmAutomatic2
}
