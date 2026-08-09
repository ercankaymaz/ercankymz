using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsModel_InvalidationHint
{
	kInvalidateIsolines = 0,
	kInvalidateViewportCache = 1,
	kInvalidateAll = 2,
	kInvalidateMaterials = 3,
	kInvalidateLinetypes = 4
}
