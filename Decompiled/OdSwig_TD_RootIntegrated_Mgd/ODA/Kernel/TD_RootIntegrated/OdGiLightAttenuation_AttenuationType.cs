using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiLightAttenuation_AttenuationType
{
	kNone = 0,
	kInverseLinear = 1,
	kInverseSquare = 2
}
