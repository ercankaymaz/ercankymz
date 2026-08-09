using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdRx_Ordering
{
	kLessThan = -1,
	kEqual = 0,
	kGreaterThan = 1,
	kNotOrderable = 2
}
