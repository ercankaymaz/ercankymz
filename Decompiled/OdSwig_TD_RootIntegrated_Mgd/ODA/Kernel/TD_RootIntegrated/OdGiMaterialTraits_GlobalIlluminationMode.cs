using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiMaterialTraits_GlobalIlluminationMode
{
	kGlobalIlluminationNone = 0,
	kGlobalIlluminationCast = 1,
	kGlobalIlluminationReceive = 2,
	kGlobalIlluminationCastAndReceive = 3
}
