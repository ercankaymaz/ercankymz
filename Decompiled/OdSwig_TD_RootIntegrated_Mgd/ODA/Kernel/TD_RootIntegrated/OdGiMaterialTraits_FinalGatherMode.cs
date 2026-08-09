using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiMaterialTraits_FinalGatherMode
{
	kFinalGatherNone = 0,
	kFinalGatherCast = 1,
	kFinalGatherReceive = 2,
	kFinalGatherCastAndReceive = 3
}
