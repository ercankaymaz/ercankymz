using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsUpdateManager_Action
{
	kAdd = 0,
	kRemove = 1,
	kNoChanges = 2
}
