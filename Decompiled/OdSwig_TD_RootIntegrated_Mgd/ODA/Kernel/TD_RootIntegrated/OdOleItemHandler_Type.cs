using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdOleItemHandler_Type
{
	kUnknown = 0,
	kLink = 1,
	kEmbedded = 2,
	kStatic = 3
}
