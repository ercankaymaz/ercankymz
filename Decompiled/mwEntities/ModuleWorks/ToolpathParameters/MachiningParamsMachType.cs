using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningParamsMachType
{
	MachtypeOneway,
	MachtypeZigzag,
	MachtypeSpiral,
	MachtypeUp,
	MachtypeDown,
	MachtypeUserDefined
}
