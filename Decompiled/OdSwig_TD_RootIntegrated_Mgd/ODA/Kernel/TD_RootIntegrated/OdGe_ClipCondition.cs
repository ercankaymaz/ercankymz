using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGe_ClipCondition
{
	kInvalid = 0,
	kAllSegmentsInside = 1,
	kSegmentsIntersect = 2,
	kAllSegmentsOutsideZeroWinds = 3,
	kAllSegmentsOutsideOddWinds = 4,
	kAllSegmentsOutsideEvenWinds = 5
}
