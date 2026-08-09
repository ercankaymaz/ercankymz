using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum HoleMakingSharedParamsPattern
{
	HmspPointsOnSurfs,
	HmspPoints,
	HmspLines,
	HmspLinesOnSurfs,
	HmspLinesOnMesh
}
