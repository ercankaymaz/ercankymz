using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsCullingVolume_IntersectionStatus
{
	kIntersectNot = 0,
	kIntersectOk = 1,
	kIntersectIn = 2
}
