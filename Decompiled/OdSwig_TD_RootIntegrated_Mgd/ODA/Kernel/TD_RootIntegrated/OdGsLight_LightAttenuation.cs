using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsLight_LightAttenuation
{
	kAttenNone = 0,
	kAttenInverseLinear = 1,
	kAttenInverseSquare = 2
}
