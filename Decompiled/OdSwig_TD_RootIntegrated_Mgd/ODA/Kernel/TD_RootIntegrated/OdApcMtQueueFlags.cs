using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdApcMtQueueFlags
{
	kMtQueueNoFlags = 0,
	kMtQueueForceNewThreads = 1,
	kMtQueueAllowExecByMain = 2,
	kMtQueueForceTopLevel = 4,
	kMtQueueLastFlag = 4
}
