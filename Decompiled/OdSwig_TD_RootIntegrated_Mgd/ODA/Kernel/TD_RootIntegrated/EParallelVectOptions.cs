using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum EParallelVectOptions
{
	eEnableParallelVectorization = 1,
	eEnableParallelDisplay = 2,
	eEnableOptimalThreadsNumber = 4,
	eEnableSchedulerLogOutput = 8,
	eEnablePerfMeasurements = 0x10,
	eForcePartialUpdateForTest = 0x20,
	eForceParallelVectorization = 0x40,
	eEnableUpdateExtentsOnly = 0x80
}
