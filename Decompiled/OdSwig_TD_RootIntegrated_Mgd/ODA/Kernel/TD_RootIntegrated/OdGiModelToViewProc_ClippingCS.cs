using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiModelToViewProc_ClippingCS
{
	kClipInEyeSpace = 0,
	kClipInWorldSpace = 1,
	kClipInOutputSpace = 2
}
