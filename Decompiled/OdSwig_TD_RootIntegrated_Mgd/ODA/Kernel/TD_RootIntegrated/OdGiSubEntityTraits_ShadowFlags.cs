using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiSubEntityTraits_ShadowFlags
{
	kShadowsCastAndReceive = 0,
	kShadowsDoesNotCast = 1,
	kShadowsDoesNotReceive = 2,
	kShadowsIgnore = 3
}
