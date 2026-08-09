using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum PortMachiningBasedTpCalcParamsPattern
{
	PmRoughing,
	PmFinishingAlong,
	PmFinishingAround,
	PmRestRoughing
}
