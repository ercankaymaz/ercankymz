using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum EMetafilePlayMode
{
	kMfUndefined = 0,
	kMfDisplay = 1,
	kMfSelect = 2,
	kMfNested = 3,
	kMfExtents = 4
}
