using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningParamsToolInspectionMethod
{
	TimByDistance,
	TimByMachiningTime,
	TimByEachCopy,
	TimNumberOfTools
}
