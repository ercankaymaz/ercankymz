using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGe_OdGeIntersectError
{
	kXXOk = 0,
	kXXIndexOutOfRange = 1,
	kXXWrongDimensionAtIndex = 2,
	kXXUnknown = 3
}
