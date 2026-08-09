using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdApcStQueueFlags
{
	kStQueueNoFlags = 0,
	kStQueueExecByMain = 1,
	kStQueueForceTopLevel = 2,
	kStQueueLastFlag = 2
}
