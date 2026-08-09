using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbMentalRayRenderSettings_ShadowSamplingMultiplier
{
	kSamplingMultiplierZero = 0,
	kSamplingMultiplierOneEighth = 1,
	kSamplingMultiplierOneFourth = 2,
	kSamplingMultiplierOneHalf = 3,
	kSamplingMultiplierOne = 4,
	kSamplingMultiplierTwo = 5
}
