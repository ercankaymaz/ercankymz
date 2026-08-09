using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum ThreadsCounter_ThreadAttributes
{
	kNoAttributes = 0,
	kMtLoadingAttributes = 1,
	kMtRegenAttributes = 2,
	kStRegenAttributes = 4,
	kMtDisplayAttributes = 8,
	kMtModelerAttributes = 0x10,
	kAllAttributes = -1
}
