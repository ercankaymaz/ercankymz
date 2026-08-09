using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningParamsCuttingAreaType
{
	AvoidCuts,
	ExactSurface,
	NumberOfCuts,
	LimitCuts
}
