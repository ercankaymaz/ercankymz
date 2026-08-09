using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MultiaxisRoughingBasedTpCalcParamsUndercutsMode
{
	UmDoNotMachine,
	UmMachine,
	UmMachineOnly,
	UmAvoidAirCuts
}
