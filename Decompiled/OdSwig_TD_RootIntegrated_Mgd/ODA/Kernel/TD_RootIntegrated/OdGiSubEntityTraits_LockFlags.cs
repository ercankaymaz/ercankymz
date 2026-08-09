using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiSubEntityTraits_LockFlags
{
	kNoLockFlags = 0,
	kLockColors = 1,
	kLockLineWeight = 2,
	kLockLineType = 4,
	kLockLineTypeScale = 8,
	kLockLayer = 0x10,
	kLockByBlockLayer = 0x20,
	kKeepAuxDataAndLockFlags = 0x40,
	kInheritableLockFlags = 0x5F
}
