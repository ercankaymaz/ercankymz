using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdEdCommandStack_LookupFlags
{
	kGlobal = 1,
	kLocal = 2,
	kSpecifedGroup = 4,
	kUndefed = 8,
	kThrowUnknown = 0x10
}
