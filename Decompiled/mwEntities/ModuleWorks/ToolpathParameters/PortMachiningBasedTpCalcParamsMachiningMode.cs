using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum PortMachiningBasedTpCalcParamsMachiningMode
{
	MmMidPoint,
	MmMaxFromTop,
	MmMaxFromBottom,
	MmUserDefined
}
