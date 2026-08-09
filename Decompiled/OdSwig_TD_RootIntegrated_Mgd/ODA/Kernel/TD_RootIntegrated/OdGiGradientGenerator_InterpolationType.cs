using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiGradientGenerator_InterpolationType
{
	kLinearInterpolation = 0,
	kExpInterpolation = 1,
	kInvExpInterpolation = 2,
	kCosInterpolation = 3
}
