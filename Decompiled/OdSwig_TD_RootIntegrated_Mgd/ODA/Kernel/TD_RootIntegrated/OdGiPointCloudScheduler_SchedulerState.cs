using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiPointCloudScheduler_SchedulerState
{
	kDisabled = 0,
	kProcessing = 1,
	kStopped = 2
}
