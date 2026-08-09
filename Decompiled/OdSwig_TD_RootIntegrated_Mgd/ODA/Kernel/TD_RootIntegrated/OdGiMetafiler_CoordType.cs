using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiMetafiler_CoordType
{
	kUnknown = 0,
	kModel = 1,
	kWorld = 2,
	kEye = 3,
	kDevice = 4
}
