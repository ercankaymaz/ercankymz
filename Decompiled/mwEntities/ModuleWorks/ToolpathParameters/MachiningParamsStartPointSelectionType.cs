using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningParamsStartPointSelectionType
{
	SmUsePosition,
	SmUseSurfaceNormal,
	SmUseNone,
	SmUseMidpointLongestLine
}
