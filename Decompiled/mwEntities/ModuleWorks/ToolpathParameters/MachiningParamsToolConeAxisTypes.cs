using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningParamsToolConeAxisTypes
{
	XAxis,
	YAxis,
	ZAxis,
	UserDefinedDir,
	UseLeadingCurve,
	UseMachiningDirection
}
