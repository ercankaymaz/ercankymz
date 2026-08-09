using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiDeviationType
{
	kOdGiMaxDevForCircle = 0,
	kOdGiMaxDevForCurve = 1,
	kOdGiMaxDevForBoundary = 2,
	kOdGiMaxDevForIsoline = 3,
	kOdGiMaxDevForFacet = 4
}
